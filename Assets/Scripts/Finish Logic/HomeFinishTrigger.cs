using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeFinishTrigger : MonoBehaviour
{
   [SerializeField] ParticleSystem particle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            EventBus.OnLevelCompleted(SceneManager.GetActiveScene().buildIndex);
            particle.Play();
        }
        
    }
}
