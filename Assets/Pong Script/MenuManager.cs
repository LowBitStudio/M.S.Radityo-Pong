using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject Menu_Page, Play_Page, Credit_Page, Guide_Page, Item_SubPage, Control_SubPage;
    [SerializeField]
    Button PrimaryMenuSelect, PrimaryPlaySelect, PrimaryCreditSelect, PrimaryGuideSelect;
    [SerializeField]
    TextMeshProUGUI Btn_Txt;
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

    bool GuideActive;
    public void Guide()
    {
        //Debug.Log("Created by M.S.R");
        GuideActive = !GuideActive;

        if(GuideActive)
        {
            SFX_Source.PlayOneShot(SFX_Clip[1]);
            Guide_Page.SetActive(true);
            Menu_Page.SetActive(false);
            PrimaryGuideSelect.Select();
        } 
        else
        {
            SFX_Source.PlayOneShot(SFX_Clip[2]);
            Guide_Page.SetActive(false);
            Menu_Page.SetActive(true);
            PrimaryMenuSelect.Select();
        }
    }

    bool ItemActive;
    public void ItemSection()
    {
        ItemActive = !ItemActive;
        if(ItemActive)
        {
            SFX_Source.PlayOneShot(SFX_Clip[1]);
            Control_SubPage.SetActive(false);
            Item_SubPage.SetActive(true);
            Btn_Txt.text = "Control";
        } 
        else
        {
            SFX_Source.PlayOneShot(SFX_Clip[1]);
            Control_SubPage.SetActive(true);
            Item_SubPage.SetActive(false);
            Btn_Txt.text = "Item";
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
