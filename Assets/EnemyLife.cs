using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Animation deathAnimation;
    private int _health;

    private void Start()
    { 
        deathAnimation=GetComponent<Animation>();
        _health = 5;
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
            
            deathAnimation.Play();
            Destroy(gameObject);
            EventBus.OnEnemyDeathEvent();
        }
    }
}
