using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    Vector2 Speed;
    [SerializeField]
    Vector2 resetpos;
    [HideInInspector]
    public Rigidbody2D rb;
    [HideInInspector]
    public bool GameStart;

    public GameObject Paddle1;
    public GameObject Paddle2;
    public string LastHit;
    
    public void ResetBall()
    {
        transform.position = new Vector2(resetpos.x, resetpos.y);
    }

    public void ActivateSpeedPU(float magnitude)
    {
        rb.velocity *= magnitude;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Is starting " + GameStart);
        //Get rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Tambahan
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(GameStart == false)
            {
                GameStart = true;
                Debug.Log("Game started");
                rb.velocity = Speed;
            }  
            else
            {
                //Apabila menekan key space lagi, tidak akan berubah dan menyatakan
                //permainan sudah dimulai
                Debug.Log("Game already started");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == Paddle1)
        {
            LastHit = Paddle1.GetComponent<PaddleControl>().PaddleName;
            Debug.Log("Hit " + LastHit);
        } 
        else if(collision.gameObject == Paddle2)
        {
            LastHit = Paddle2.GetComponent<PaddleControl>().PaddleName;
            Debug.Log("Hit " + LastHit);
        }
    }
}
