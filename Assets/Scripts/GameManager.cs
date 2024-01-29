using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject gameOverScreen;

    public Button restartButton;
    
    private bool _gameIsActive;
    private PlayerLife _playerLife;
    public override void Awake()
    {
        if (titleScreen == null)
        {
            titleScreen = Instance.titleScreen;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        _playerLife=FindAnyObjectByType<PlayerLife>();
       
    }

    // Update is called once per frame
    void Update()
    {
        RestartGame();
    }

    public void StartGame() 
    {
        _gameIsActive = true;
        SceneManager.LoadScene("Summer");
    }

    public void PauseGame()
    {

    }

    private void RestartGame()
    {
       
        if (_playerLife.isDead)
        {
            titleScreen.SetActive(true);
            restartButton.gameObject.SetActive(true);
            _gameIsActive = false;
        }
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
