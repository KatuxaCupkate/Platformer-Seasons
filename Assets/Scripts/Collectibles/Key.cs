using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

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
}
