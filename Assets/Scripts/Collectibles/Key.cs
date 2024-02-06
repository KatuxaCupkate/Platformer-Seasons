using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Key : MonoBehaviour
{
   // [SerializeField] private Text keys;

   // public int _keyCount { get; private set; }

    private void Start()
    {
        //_keyCount = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
           // _keyCount++;
            //keys.text = "Key " + _keyCount;
            EventBus.OnItemPickedUpEvent("Key");
            Destroy(gameObject);
        }
    }
}
