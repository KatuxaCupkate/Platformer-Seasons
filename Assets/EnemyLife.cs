using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
  
    [SerializeField] private int _health;

    private void Start()
    { 
       
    }
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
        _health--;
        EventBus.OnEnemyGetDamage();
        
    }

    private void Die()
    {
        if(_health==0)
        {
            Destroy(gameObject);
            EventBus.OnEnemyDeathEvent();
        }
    }
}
