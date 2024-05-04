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

    public void AddHomeScore(int increament)
    {
        _homeScore += increament;
        ball.ResetBall();

        if(_homeScore == _maxScore)
        {
            GameOver();
        }
    }

    public void AddAwayScore(int increament)
    {
        _awayScore += increament;
        ball.ResetBall();
        
        if(_awayScore == _maxScore)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
