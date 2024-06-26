using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.PlayerLoop;

public enum alphavalue
{
    Shrinking,
    Growing
}

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject Start_Panel;
    [SerializeField]
    GameObject PausePage;
    [SerializeField]
    GameObject FinishPage;
    [SerializeField]
    Button FirstSelected;
    GameInputAction Input;

    [Header("Start Page")]
    public alphavalue CurrentValue;
    public float CommentMinAlpha;
    public float CommentMaxAlpha;
    public float CommentCurrentAlpha;
    public TextMeshProUGUI StartText;

    [Header("Finish Page")]
    public TextMeshProUGUI FinishText;

    private void Awake()
    {
        Input = new GameInputAction();
        Start_Panel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Start()
    {
        CommentMinAlpha = 0f;
        CommentMaxAlpha = 1f;
        CommentCurrentAlpha = 1f;
        CurrentValue = alphavalue.Shrinking;
    }

    private void Update()
    {
        AlphaComments();
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

    public void StartGame()
    {
        Start_Panel.SetActive(false);
        Time.timeScale = 1f;
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

    public void P1Wins()
    {
        FinishPage.SetActive(true);
        FinishText.text = "P1 WINS";
        Time.timeScale = 0;
    }
    public void P2Wins()
    {
        FinishPage.SetActive(true);
        FinishText.text = "P2 WINS";
        Time.timeScale = 0;
    }

    public void AlphaComments()
    {
        if(CurrentValue == alphavalue.Shrinking)
        {
            CommentCurrentAlpha -= 0.01f;
            StartText.color = new Color(Color.white.r, Color.white.g, Color.white.b, CommentCurrentAlpha);
            if (CommentCurrentAlpha <= CommentMinAlpha)
            {
                CurrentValue = alphavalue.Growing;
            }
        }
        else if(CurrentValue == alphavalue.Growing)
        {
            CommentCurrentAlpha += 0.01f;
            StartText.color = new Color(Color.white.r, Color.white.g, Color.white.b, CommentCurrentAlpha);
            if (CommentCurrentAlpha >= CommentMaxAlpha)
            {
                CurrentValue = alphavalue.Shrinking;
            }
        }
    }
}
