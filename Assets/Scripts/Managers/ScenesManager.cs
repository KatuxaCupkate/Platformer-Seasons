using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class ScenesManager : Singleton<ScenesManager>
{
    [SerializeField] private Animator _transitionAnimation;
    [SerializeField] private float _transitionTime;
 

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
       SceneManager.LoadScene("Summer");
    }
    // Reload present level on Restart button click
    public void ReloadLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       EventBus.OnLevelRestarted();
    }
    private void LoadNextScene(int activeSceneIndex)
    {
        StartCoroutine(LoadTransition(activeSceneIndex+1));  
        EventBus.OnLevelRestarted();
    
    }

    private  IEnumerator LoadTransition(int sceneIndex)
    {
       _transitionAnimation.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnLevelWasLoaded(int level)
    {
        _transitionAnimation.Play("LevelTrans_End");
        
    }
}
