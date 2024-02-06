using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coins : MonoBehaviour 
{
    private int _pickedAmount;

    private void Start()
    {
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            EventBus.OnItemPickedUpEvent("Coin");
            _pickedAmount++;
            EventBus.OnBalanceChangedEvent(_pickedAmount);  // Create event
            Destroy(gameObject,0.1f);
        }
    }

   
}
