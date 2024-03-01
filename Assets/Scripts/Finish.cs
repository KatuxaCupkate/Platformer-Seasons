using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject cloudPlatform;
    public bool levelCompleted = false;

    private int _requireCoinsAmount = 50;
    private int _requireKeysAmount = 1;

    // TODO 
    // cut-scene "go home" after chek req.
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player"))
        {
            if (PlayerCanPass() && Input.GetKeyDown(KeyCode.K))
            {
                EventBus.OnLevelComplited(SceneManager.GetActiveScene().buildIndex);
                levelCompleted = true;
            }
            
        }
        
    }
   

    private bool PlayerCanPass()
    {
        bool isPlayerPass = false;
        switch (SceneManager.GetActiveScene().name)

        {
            case ("Summer"):
                if (Wallet.Instance.KeyCount == _requireKeysAmount)
                {
                    isPlayerPass = true;
                  

                }
                break;
            case ("Autumn"):
                if (Wallet.Instance.Balance >= _requireCoinsAmount|| Wallet.Instance.KeyCount == _requireKeysAmount)
                { 
                    isPlayerPass = true;
                    ActivatePlatform(isPlayerPass);
                }
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

     private void ActivatePlatform(bool PlayerCanPass)
    {
        
        var waipointBeh =  cloudPlatform.GetComponent<WaypointFollower>();
        waipointBeh.enabled = PlayerCanPass;
    }

   
}
