using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerLife : MonoBehaviour
{
    public bool isDead=false;
    private CapsuleCollider2D colliderPlayer;
    private Rigidbody2D rb;
    private Animator animator;
    public float deathDelay = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        colliderPlayer = GetComponent<CapsuleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && !isDead)// Death animations
        {  
            Die();
        }
       
    }

    private void Die()
    {
        
        isDead = true;
        rb.velocity = Vector2.zero;
       // colliderPlayer.enabled = false;
        animator.SetTrigger("Death");
        
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
