using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI _scoreHome;
    public TextMeshProUGUI _scoreAway;
    public ScoreManager manager;
    
    private void Update()
    {
        _scoreHome.text = manager._homeScore.ToString();
        _scoreAway.text = manager._awayScore.ToString();
    }
}
