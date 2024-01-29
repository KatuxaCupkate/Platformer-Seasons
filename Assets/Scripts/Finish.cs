using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public bool levelCompleted = false;
   
    private ItemCollector itemSc;

    private void Start()
    {
            
    }
    // TODO 
    // cut-scene "go home" after chek req.
    private void OnTriggerStay2D(Collider2D collision)
    {
            itemSc=collision.GetComponent<ItemCollector>();

        if ( collision.CompareTag("Player")&& itemSc.keysCounter > 0 && Input.GetKeyDown(KeyCode.K))
        {
            Invoke("LoadNextScene",0f);
            levelCompleted = true;
            itemSc.keysCounter--;
        }
        
    }

   
    //cut-scene 

    private void LoadNextScene()
    {
        
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }


 
}
