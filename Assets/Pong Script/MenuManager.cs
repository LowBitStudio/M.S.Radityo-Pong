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
    [SerializeField]
    AudioSource SFX_Source;
    [SerializeField]
    AudioClip[] SFX_Clip = new AudioClip[3];

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Start()
    {
        PrimaryMenuSelect.Select();
    }

    public void OnePlayer_Scene()
    {
        SFX_Source.PlayOneShot(SFX_Clip[1]);
        SceneManager.LoadScene("Pong AI");
    }
    public void TwoPlayer_Scene()
    {
        SFX_Source.PlayOneShot(SFX_Clip[1]);
        SceneManager.LoadScene("Pong");
    }
    bool PlayActive;
    
    public void Play()
    {
        PlayActive = !PlayActive;

        if(PlayActive)
        {
            SFX_Source.PlayOneShot(SFX_Clip[1]);
            Play_Page.SetActive(true);
            Menu_Page.SetActive(false);
            PrimaryPlaySelect.Select();
        }
        else
        {
            SFX_Source.PlayOneShot(SFX_Clip[2]);
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
            SFX_Source.PlayOneShot(SFX_Clip[1]);
            Credit_Page.SetActive(true);
            Menu_Page.SetActive(false);
            PrimaryCreditSelect.Select();
        } 
        else
        {
            SFX_Source.PlayOneShot(SFX_Clip[2]);
            Credit_Page.SetActive(false);
            Menu_Page.SetActive(true);
            PrimaryMenuSelect.Select();
        }
    }
    public void OpenUrl(string URL)
    {
        SFX_Source.PlayOneShot(SFX_Clip[1]);
        Application.OpenURL(URL);
    }
    public void QuitGame()
    {
        SFX_Source.PlayOneShot(SFX_Clip[2]);
        Application.Quit();
        Debug.Log("Quitting....");
    }
}
