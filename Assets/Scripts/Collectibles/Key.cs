using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

[RequireComponent (typeof (Collider2D))]
[RequireComponent (typeof (Rigidbody2D))]

public class Key : MonoBehaviour
{
    private Rigidbody2D keyRigidbody;
    private float _inpulsforce = 3;
    private int _amount;
    private void Start()
    {
        keyRigidbody = GetComponent<Rigidbody2D> ();
        keyRigidbody.AddForce(new Vector2(-1,1) * _inpulsforce, ForceMode2D.Impulse);
    }
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
