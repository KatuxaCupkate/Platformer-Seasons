using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class ItemCollector : Singleton<ItemCollector>
{
    //  [SerializeField] private PikableType type; // create inventory
     private int coinsCounter;
     public int keysCounter;
    
    [SerializeField] private Text coins;
    [SerializeField] private Text keys;
    [SerializeField] private AudioSource[] collectedAudio;


   
    private bool chestIsOpen;

    private void Start()
    {
        if (ItemCollector.Instance!=null)
        {
            this.coinsCounter=ItemCollector.Instance.coinsCounter;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collectedAudio[0].Play();
            
            coinsCounter++;
            Destroy(collision.gameObject);
            coins.text = "" + coinsCounter;
        }
        if (collision.gameObject.CompareTag("Chest")) // Opening Chest (to add: instans coins)
        {
            if (!chestIsOpen)
            { collectedAudio[1].Play(); }
           chestIsOpen = true;
           collision.gameObject.GetComponent<Animator>().SetBool("IsOpen", chestIsOpen);
           
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            collectedAudio[2].Play();
            
            keysCounter++;
            keys.text = "Key: " + keysCounter;
            Destroy(collision.gameObject);
        }
    }
}
