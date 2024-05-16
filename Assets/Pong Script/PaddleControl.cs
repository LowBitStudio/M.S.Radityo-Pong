using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    //Var
    Vector3 DefaultScale = new Vector3(0.3f, 2, 1);
    Vector3 NewScale = new Vector3(0.3f, 4, 1);

    public string PaddleName;

    float _paddleSpeed;
    [SerializeField] 
    float defaultSpeed;
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
        rb = GetComponent<Rigidbody2D>();
        transform.localScale = DefaultScale;
        _paddleSpeed = defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        PaddleMovement(movement());
    }
}
