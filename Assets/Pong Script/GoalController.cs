using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public Collider2D ball;
    public bool isRight;
    public ScoreManager manager;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other == ball)
        {
            if(isRight)
            {
                manager.AddHomeScore(1);
            } 
            else
            {
                manager.AddAwayScore(1);
            }
            ball.GetComponent<Ball>().GameStart = false; //Game is not starting
            ball.GetComponent<Ball>().rb.velocity = Vector2.zero; //Speed is stop
        }
    }
}
