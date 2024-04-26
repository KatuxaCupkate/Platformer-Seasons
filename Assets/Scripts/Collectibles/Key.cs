using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

[RequireComponent (typeof (Collider2D))]
[RequireComponent (typeof (Rigidbody2D))]

public class Key : MonoBehaviour
{ 
    private int _amount;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _amount++;
            EventBus.OnItemPickedUpEvent(gameObject.tag,_amount);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("NPC"))
        {
            EventBus.OnItemPickedUpEvent(gameObject.tag,-1);
            Destroy(gameObject);
        }
    }
}
