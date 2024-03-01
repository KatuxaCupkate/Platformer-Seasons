using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class ScenesManager : Singleton<ScenesManager>
{

    private void OnEnable()
    {
        EventBus.LevelCompletedEvent += LoadNextScene;
    }
    private void OnDisable()
    {
        EventBus.LevelCompletedEvent -= LoadNextScene;
        
    }
    // Start game from Start screen on Start button click
    public void StartGame()
    {
        //TODO 
        // Choose level 
        
        SceneManager.LoadScene("Summer");
    }
    // Reload present level on Restart button click
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        EventBus.OnLevelRestarted();
        
    }
    private void LoadNextScene(int sceneIndex)
    {

        SceneManager.LoadScene(sceneIndex + 1);
        EventBus.OnLevelRestarted();

    }
}
