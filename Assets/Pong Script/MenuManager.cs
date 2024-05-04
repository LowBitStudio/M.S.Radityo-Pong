using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGames()
    {
        SceneManager.LoadScene("Pong");
    }
    public void Credit()
    {
        Debug.Log("Created by M.S.R");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting....");
    }
}
