using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
