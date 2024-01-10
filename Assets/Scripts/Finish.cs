using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public bool finish = false;
   
   [SerializeField] private ItemCollector itemSc;
    // TODO 
    // cut-scene "go home" after chek req.

    private void Update()
    {
        if (itemSc.keysCounter > 0 && Input.GetKeyDown(KeyCode.K))
        { Invoke("ComleteLevel", 2f); }

    }
    //cut-scene 

    private void ComleteLevel()
    {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

 
}
