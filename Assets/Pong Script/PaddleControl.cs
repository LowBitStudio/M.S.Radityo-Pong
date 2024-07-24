using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PaddleControl : MonoBehaviour
{
    //Var
    Vector3 DefaultScale = new Vector3(0.3f, 2, 1);
    Vector3 NewScale = new Vector3(0.3f, 4, 1);

    public GameObject ball;

    public string PaddleName;

    float _paddleSpeed;
    [SerializeField] 
    float defaultSpeed;
    [SerializeField]
    InputAction _move;
    Rigidbody2D rb;

    private string sceneName;
    private bool IsAI;

    private void OnEnable()
    {
        _move.Enable();
    }

    private void OnDisable()
    {
        _move.Disable();
    }

    //Controls here
    Vector2 movement()
    {
        return _move.ReadValue<Vector2>() * _paddleSpeed;
    }
    Vector2 AIMovement()
    {
        if(ball.transform.position.y > transform.position.y + 1)
        {
            return new Vector2(0,1) * _paddleSpeed;
        }
        else if(ball.transform.position.y < transform.position.y - 1)
        {
            return new Vector2(0,-1) * _paddleSpeed;
        }
        else
        {
            return new Vector2(0,0);
        }
    }

    //Power Up Functions
    public void ActivateLongPaddle()
    {
        transform.localScale = NewScale;
        StartCoroutine(DisableLongPaddle());
    }
    public void ActivateSpeedyPaddle()
    {
        _paddleSpeed *= 2;
        StartCoroutine(DisableSpeedyPaddle());
    }
    private IEnumerator DisableLongPaddle()
    {
        yield return new WaitForSeconds(5);
        transform.localScale = DefaultScale;
    }
    private IEnumerator DisableSpeedyPaddle()
    {
        yield return new WaitForSeconds(5);
        _paddleSpeed = defaultSpeed;
    }

    //Paddle movement
    private void PaddleMovement(Vector2 movement)
    {
        //Check the paddle speed
        //Debug.Log("TEST: " + movement); //Alternatifnya bisa pakai rb.velocity.magnitude
        //Speed paddle
        rb.velocity = movement;
    }

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if(sceneName == "Pong AI")
        {
            IsAI = true;
        }

        rb = GetComponent<Rigidbody2D>();
        transform.localScale = DefaultScale;
        _paddleSpeed = defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsAI && PaddleName == "Paddle 2")
        {
            PaddleMovement(AIMovement());
        } 
        else
        {
            PaddleMovement(movement());
        }
    }
}
