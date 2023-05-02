using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public enum PikableType { Coins, Keys } // for adding to Inventory in Game Manager script
public class ItemCollector : MonoBehaviour
{
    [SerializeField] private PikableType type; // create inventory
    [SerializeField] private int coinsCounter;
    [SerializeField] private int keysCounter;
    [SerializeField] private Text coins;
    [SerializeField] private Text keys;
    private Animator animator;
    private bool chestIsOpen = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            type = PikableType.Coins;
            coinsCounter++;
            Destroy(collision.gameObject);
            coins.text =""+coinsCounter;
        }
        if (collision.gameObject.CompareTag("Chest")) // Opening Chest (to add: instans coins and a key)
        {
            chestIsOpen = true;
            animator = collision.gameObject.GetComponent<Animator>();
            animator.SetBool("IsOpen", chestIsOpen);
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            type = PikableType.Keys;
            keysCounter++;
            keys.text = "Key: " + keysCounter;
            Destroy(collision.gameObject);
        }
    }
}
