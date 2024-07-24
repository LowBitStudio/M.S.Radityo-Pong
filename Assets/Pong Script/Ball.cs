using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    Vector2 BallDir = new Vector2(1, 0);
    Vector2 resetpos = new Vector2(0, 0);
    float BallSpeed = 10;
    float SpeedIncrease = 0.25f;
    float HitCounter;
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public bool GameStart, canpause;

    public GameObject Paddle1;
    public GameObject Paddle2;
    public UI_Manager UI;
    public string LastHit;
    public string WhoServed;
    [Header("Visual Effects")]
    public ParticleSystem BallParticle;
    public SpriteRenderer sr;
    [Header("Audio")]
    public AudioSource SFX_Source;
    public AudioClip[] SFX_Clip;
    GameInputAction Input;
    
    private void Awake()
    {
        Input = new GameInputAction();
        WhoServed = "P1 Served";
        HitCounter = 0;
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Input.Player.Start.performed += StartTheGame;
        Input.Player.Enable();
    }

    private void OnDisable()
    {
        Input.Player.Start.performed -= StartTheGame;
        Input.Player.Disable();
    }

    public void BallDisappear()
    {
        BallParticle.Play(); //Play the particle
        sr.enabled = false; //turn sprite off
        SFX_Source.PlayOneShot(SFX_Clip[1]); //Play the blast sfx
    }
    public IEnumerator ResetBall()
    {
        BallDisappear();
        yield return new WaitForSeconds(2f);
        sr.enabled = true; //Turn back the renderer
        transform.position = new Vector2(resetpos.x, resetpos.y); //reset the position
        HitCounter = 0;
    }

    public void ActivateSpeedPU(float magnitude)
    {
        rb.velocity *= magnitude;
    }

    public void StartTheGame(InputAction.CallbackContext context)
    {
        if(GameStart == false)
        {
            GameStart = true;
            canpause = true;
            Debug.Log("Game started");
            //Serve the ball, if it's player win it'll be directed to the opponent
            if(WhoServed == "P1 Served") rb.velocity = BallDir * (BallSpeed + SpeedIncrease * HitCounter); //Kanan
            else if(WhoServed == "P2 Served") rb.velocity = -BallDir * (BallSpeed + SpeedIncrease * HitCounter); //Kiri
            UI.StartGame();
        }  
        else
        {
            //Apabila menekan key space lagi, tidak akan berubah dan menyatakan
            //permainan sudah dimulai
            Debug.Log("Game already started");
        }
    }

    private void BallBounce(Transform myObject)
    {
        //Make the ball increase speed on each hit counter
        HitCounter++;
        //Make the ball on different angle not straight line
        Vector2 ballpos = transform.position;
        Vector2 playerpos = myObject.transform.position;

        float xDir, yDir;
        if(transform.position.x > 0)
        {
            xDir = -1;
        }
        else
        {
            xDir = 1;
        }

        yDir = (ballpos.y - playerpos.y) / myObject.GetComponent<Collider2D>().bounds.size.y;
        if(yDir == 0)
        {
            yDir = 0.25f;
        }

        rb.velocity = new Vector2(xDir, yDir) * (BallSpeed + (SpeedIncrease + HitCounter));
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Is starting " + GameStart);
        //Get rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, BallSpeed + (SpeedIncrease * HitCounter));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == Paddle1)
        {
            LastHit = Paddle1.GetComponent<PaddleControl>().PaddleName;
            Debug.Log("Hit " + LastHit);
            //Play the hit sfx
            SFX_Source.PlayOneShot(SFX_Clip[0]);
        } 
        else if(collision.gameObject == Paddle2)
        {
            LastHit = Paddle2.GetComponent<PaddleControl>().PaddleName;
            Debug.Log("Hit " + LastHit);
            //Play the hit sfx
            SFX_Source.PlayOneShot(SFX_Clip[0]);
        }

        if(collision.gameObject.tag == "Wall")
        {
            //Play the wall sfx
            SFX_Source.PlayOneShot(SFX_Clip[2]);
        }

        if(collision.gameObject == Paddle1 || collision.gameObject == Paddle2)
        {
            BallBounce(collision.transform);
        }
    }
}
