using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject Menu_Page, Play_Page, Credit_Page;
    [SerializeField]
    Button PrimaryMenuSelect, PrimaryPlaySelect, PrimaryCreditSelect;

    public void Start()
    {
        PrimaryMenuSelect.Select();
    }

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
    
    public void Play()
    {
        PlayActive = !PlayActive;

        if(PlayActive)
        {
            Play_Page.SetActive(true);
            Menu_Page.SetActive(false);
            PrimaryPlaySelect.Select();
        }
        else
        {
            Play_Page.SetActive(false);
            Menu_Page.SetActive(true);
            PrimaryMenuSelect.Select();
        }
    }

    bool CreditActive;
    public void Credit()
    {
        //Debug.Log("Created by M.S.R");
        CreditActive = !CreditActive;

        if(CreditActive)
        {
            Credit_Page.SetActive(true);
            Menu_Page.SetActive(false);
            PrimaryCreditSelect.Select();
        } 
        else
        {
            Credit_Page.SetActive(false);
            Menu_Page.SetActive(true);
            PrimaryMenuSelect.Select();
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
