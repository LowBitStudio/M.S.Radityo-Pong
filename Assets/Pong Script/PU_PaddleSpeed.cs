using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PU_PaddleSpeed : MonoBehaviour
{
    [Header("Item Setting")]
    public PU_Manager PUM;
    public Collider2D ball;
    public GameObject paddle1;
    public GameObject paddle2;

    [Header("Item SFX")]
    public string PU_Name = "Fast Paddle";
    public GameObject FloatingTextPrefab;
    public Collider2D PowerUpCollider;
    public SpriteRenderer sr;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other == ball)
        {
            //Activate power up
            //Last hit is Paddle 1
            if(ball.GetComponent<Ball>().LastHit == "Paddle 1")
            {
                paddle1.GetComponent<PaddleControl>().ActivateSpeedyPaddle();
            }
            //Last hit is Paddle 2
            else if(ball.GetComponent<Ball>().LastHit == "Paddle 2")
            {
                paddle2.GetComponent<PaddleControl>().ActivateSpeedyPaddle();
            }
            //No last hit
            else if(ball.GetComponent<Ball>().LastHit == null)
            {
                return;
            }
            //Destroy the object
            StartCoroutine(BallHit());
        } 
    }

    private void Start()
    {
        if(gameObject.activeSelf) //Read if game object is active
        {
            sr = GetComponent<SpriteRenderer>();
            PowerUpCollider = GetComponent<Collider2D>();
            //Debug.Log(gameObject.name + " is active.");
            StartCoroutine(Timer());
        }
    }

    void ShowFloatingText()
    {
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMeshPro>().text = PU_Name;
    }

    public IEnumerator BallHit()
    {
        sr.enabled = false;
        PowerUpCollider.enabled = false;
        ShowFloatingText();
        yield return new WaitForSeconds(1.31f);
        //Destroy the object
        PUM.RemovePowerUp(gameObject);
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        PUM.RemovePowerUp(gameObject);
    }
}
