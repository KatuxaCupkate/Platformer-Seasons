using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.ComponentModel;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerLife : Singleton<PlayerLife> 
{
   
    private bool isDead=false;
    private Rigidbody2D rb;
    private Animator animator;
   

    [SerializeField] private AudioSource dethAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isDead)// Death animations
        {
            Die();
        }
    }

    private void Die()
    {
        dethAudioSource.Play();
        EventBus.OnPlayerDethEvent(); // create death event for game manager 
        isDead = true;
        animator.SetTrigger("Death");
        
    }

    

}
