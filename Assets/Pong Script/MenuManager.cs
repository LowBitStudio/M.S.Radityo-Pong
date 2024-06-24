using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject Menu_Page;

    public void OnePlayer_Scene()
    {
        SceneManager.LoadScene("Pong");
    }
    public void TwoPlayer_Scene()
    {
        Debug.Log("Coming Soon");
        //SceneManager.LoadScene("Pong");
    }
    bool PlayActive;
    [SerializeField]
    GameObject Play_Page;
    public void Play()
    {
        PlayActive = !PlayActive;

        if(PlayActive)
        {
            Play_Page.SetActive(true);
            Menu_Page.SetActive(false);
        }
        else
        {
            Play_Page.SetActive(false);
            Menu_Page.SetActive(true);
        }
    }

    bool CreditActive;
    [SerializeField]
    GameObject Credit_Page;
    public void Credit()
    {
        //Debug.Log("Created by M.S.R");
        CreditActive = !CreditActive;

        if(CreditActive)
        {
            Credit_Page.SetActive(true);
            Menu_Page.SetActive(false);
        } 
        else
        {
            Credit_Page.SetActive(false);
            Menu_Page.SetActive(true);
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
