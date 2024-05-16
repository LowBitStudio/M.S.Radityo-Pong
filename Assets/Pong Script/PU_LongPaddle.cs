using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_LongPaddle : MonoBehaviour
{
    public PU_Manager PUM;
    public Collider2D ball;
    public GameObject paddle1;
    public GameObject paddle2;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other == ball)
        {
            //Activate power up
            //Last hit is Paddle 1
            if(ball.GetComponent<Ball>().LastHit == "Paddle 1")
            {
                paddle1.GetComponent<PaddleControl>().ActivateLongPaddle();
            }
            //Last hit is Paddle 2
            else if(ball.GetComponent<Ball>().LastHit == "Paddle 2")
            {
                paddle2.GetComponent<PaddleControl>().ActivateLongPaddle();
            }
            //No last hit
            else if(ball.GetComponent<Ball>().LastHit == null)
            {
                return;
            }
            //Destroy the object
            PUM.RemovePowerUp(gameObject);
        } 
    }

    private void Start()
    {
        if(gameObject.activeSelf) //Read if game object is active
        {
            //Debug.Log(gameObject.name + " is active.");
            StartCoroutine(Timer());
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        PUM.RemovePowerUp(gameObject);
    }
}
