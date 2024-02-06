using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public bool levelCompleted = false;

    Wallet wallet;

    private void Start()
    {
            
    }
    // TODO 
    // cut-scene "go home" after chek req.
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player"))
        {
            wallet = collision.GetComponent<Wallet>();
            if (wallet._keyCount > 0 && Input.GetKeyDown(KeyCode.K))
            {
                Invoke("LoadNextScene", 0f);
                levelCompleted = true;
            }
            
        }
        
    }

   
    //cut-scene 

    private void LoadNextScene()
    {
        
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }


 
}
