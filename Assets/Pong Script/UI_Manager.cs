using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject PausePage;
    [SerializeField]
    Button FirstSelected;
    GameInputAction Input;

    private void Awake()
    {
        Input = new GameInputAction();
        Time.timeScale = 1f;
    }

    private void OnEnable()
    {
        Input.UI.Pause.performed += PauseGame;
        Input.UI.Enable();
    }

    private void OnDisable()
    {
        Input.UI.Pause.performed -= PauseGame;
        Input.UI.Disable();
    }

    bool IsPaused;
    public void PauseGame(InputAction.CallbackContext context)
    {
        IsPaused = !IsPaused;

        if(IsPaused)
        {
            PausePage.SetActive(true);
            FirstSelected.Select();
            Time.timeScale = 0;
        }
        else
        {
            PausePage.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Continue()
    {
        IsPaused = false;
        PausePage.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Continue the game");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Pong");
    }
}
