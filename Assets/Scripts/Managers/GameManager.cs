using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button restartButton;

    private bool _paused;
    private bool _gameIsActive;
    public override void Awake()
    {
        if (titleScreen == null)
        {
            titleScreen = Instance.titleScreen;
        }
        if (exitButton == null)
            exitButton = Instance.exitButton;
        if (restartButton == null)
            restartButton = Instance.restartButton;

    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }
    private void OnEnable()
    {
        EventBus.PlayerDeathEvent += RestartGame; //subscribe to player death event
    }
    private void OnDisable()
    {
        EventBus.PlayerDeathEvent -= RestartGame;
    }


    public void PauseGame()
    {
        if (!_paused)
        {
            pauseScreen.SetActive(true);
            exitButton.gameObject.SetActive(true);
            _paused = true;
            Time.timeScale = 0;
        }
        else
        {
            pauseScreen.SetActive(false);
            exitButton.gameObject.SetActive(false);
            _paused = false;
            Time.timeScale = 1;
        }
        //TODO
    }

    // Pop-up title screen and restart button on player's death 
    private void RestartGame()
    {
       
        titleScreen.SetActive(true);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        _gameIsActive = false;
        
    }

    // Exit application on button click
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
