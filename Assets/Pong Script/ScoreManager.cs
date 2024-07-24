using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int _homeScore;
    public int _awayScore;
    public int _maxScore;
    public Ball ball;
    public UI_Manager UI;

    public void AddHomeScore(int increament)
    {
        _homeScore += increament;
        StartCoroutine(ball.ResetBall());

        if(_homeScore == _maxScore)
        {
            ball.BallDisappear();
            //UI text said that P1 wins
            StartCoroutine(UI.P1Wins());
        }
    }

    public void AddAwayScore(int increament)
    {
        _awayScore += increament;
        StartCoroutine(ball.ResetBall());
        
        if(_awayScore == _maxScore)
        {
            ball.BallDisappear();
            //UI text said that P2 Wins
            StartCoroutine(UI.P2Wins());
        }
    }
}
