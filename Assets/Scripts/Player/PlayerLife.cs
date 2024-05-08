using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.ComponentModel;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerLife : MonoBehaviour
{
   
    private bool isDead;
    private Rigidbody2D rb;
    private Animator animator;
   

    [SerializeField] private AudioSource deathAudioSource;

    // Start is called before the first frame update
   public void Initialize(GameObject Player)
    {
        rb = Player.GetComponent<Rigidbody2D>();
        animator = Player.GetComponent<Animator>();
        isDead = false;
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        //sdeathAudioSource.Play();
        EventBus.OnPlayerDeathEvent(); 
        isDead = true;
        animator.SetTrigger("Death");
        
    }

    

}
