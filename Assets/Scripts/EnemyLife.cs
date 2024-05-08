using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
  
    [SerializeField] private int Health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Snow Ball"))
        {
            
            GetDamage();
            Die();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        sprite.color = Color.white;
    }
    private void GetDamage()
    {
        sprite.color = Color.red;
        Health--;
        EventBus.OnEnemyGetDamage();
        
    }

    private void Die()
    {
        if(Health==0)
        {
            Destroy(gameObject);
            EventBus.OnEnemyDeathEvent();
        }
    }
}
