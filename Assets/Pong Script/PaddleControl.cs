using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    //Var
    [SerializeField]
    float _paddleSpeed;
    [SerializeField]
    KeyCode Up, Down;
    Rigidbody2D rb;

    //Controls here
    Vector2 movement()
    {
        //Go up
        if(Input.GetKey(Up))
        {
            return Vector2.up * _paddleSpeed;
        }
        //Go down
        else if(Input.GetKey(Down))
        {
            return Vector2.down * _paddleSpeed;
        } 
        //When not input
        return Vector2.zero;
    }

    //Paddle movement
    private void PaddleMovement(Vector2 movement)
    {
        //Check the paddle speed
        Debug.Log("TEST: " + movement); //Alternatifnya bisa pakai rb.velocity.magnitude
        //Speed paddle
        rb.velocity = movement;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _paddleSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        PaddleMovement(movement());
    }
}
