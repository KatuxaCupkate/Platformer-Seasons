using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject mobileInput;
   private NewControls _controls;
    private bool _paused;
   
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

      _controls = new NewControls();
      _controls.Enable();
      

    }
    
    private void OnEnable()
    {
        EventBus.PlayerDeathEvent += RestartGame; //subscribe to player death event
        _controls.GameManage.Pause.performed += PauseGame;
    }
    private void OnDisable()
    {
        _controls.GameManage.Pause.performed -= PauseGame;
        EventBus.PlayerDeathEvent -= RestartGame;
    }


    public void PauseGame(InputAction.CallbackContext context)
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
        mobileInput.SetActive(false);
        titleScreen.SetActive(true);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        
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
