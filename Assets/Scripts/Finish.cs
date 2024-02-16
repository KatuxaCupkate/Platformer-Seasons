using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public bool levelCompleted = false;

    private int _requireCoinsAmount = 50;
    private int _requireKeysAmount = 1;

    private void Start()
    {
        
            
    }
    // TODO 
    // cut-scene "go home" after chek req.
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player"))
        {
            if (Wallet.Instance.KeyCount > 0 && Input.GetKeyDown(KeyCode.K))
            {
                Invoke("LoadNextScene",0f);
                levelCompleted = true;
            }
            
        }
        
    }

    private void LoadNextScene()
    {
        
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    private bool CheckRequierments()
    {
        bool isPlayerPass = false;
        switch (SceneManager.GetActiveScene().name)

        {
            case ("Summer"):
                if (Wallet.Instance.KeyCount == _requireKeysAmount)
                isPlayerPass=true;
                break;
            case ("Autum"):
                if(Wallet.Instance.Balance >= _requireCoinsAmount)
                    isPlayerPass = true;
                break;
            case ("Winter"):
                // TODO 
                //Enemy Dead?
                isPlayerPass =false;
                break;
            default:
                isPlayerPass = false;
                break;

        }
        return isPlayerPass;
    }

 
}
