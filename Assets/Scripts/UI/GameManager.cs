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
    
    private bool _gameIsActive;

    public override void Awake()
    {
        if (titleScreen == null)
        {
            titleScreen = Instance.titleScreen;
        }
    }
    private void OnEnable()
    {
        EventBus.PlayerDeathEvent +=RestartGame; //subscribe to player death event
    }
    private void OnDisable()
    {
        EventBus.PlayerDeathEvent -= RestartGame;
    }

    // Start game from Start screen
    public void StartGame() 
    {
        //TODO 
        // Choose level 
        _gameIsActive = true;
        SceneManager.LoadScene("Summer");
    }

    public void PauseGame()
    {
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

    // Reload present level on button click
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Exit application on buttun click
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
