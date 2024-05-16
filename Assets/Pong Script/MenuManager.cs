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
    
    bool CreditActive;
    [SerializeField]
    GameObject Credit_button;
    public void Credit()
    {
        //Debug.Log("Created by M.S.R");
        CreditActive = !CreditActive;

        if(CreditActive)
        {
            Credit_button.SetActive(true);
        } 
        else
        {
            Credit_button.SetActive(false);
        }
    }
    public void OpenUrl()
    {
        Application.OpenURL("https://github.com/SnoopFraud");
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting....");
    }
}
