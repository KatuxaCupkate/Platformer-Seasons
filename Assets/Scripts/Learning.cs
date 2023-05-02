using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learning : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        int playerWallet = 100;
        Dictionary<string, int> itemInventory = new Dictionary<string, int>()
        {
            { "Potion", 5},
            { "Antidote", 7},
            { "Aspirin", 11}
        };

        foreach (KeyValuePair<string,int> kvp in itemInventory)
        {
            if (kvp.Value <= playerWallet)
            {
                Debug.Log("You can buy:" + kvp.Key + " for - "+ kvp.Value);
                playerWallet-=kvp.Value;
                Debug.Log("Wallet: " + playerWallet);
            }
            else
            {
                Debug.Log("No money - no honey!");
            }
        }
        /*   int diceRoll = Random.Range(7, 15);
          //string characterAction = "Heal";
          switch (diceRoll)
          {
              case 7:
              case 15:
                  Debug.Log("Midiocre damage, not bad");
                  break;
                  case 20:
                  Debug.Log("Critical hit, the creature goes down");
                  break;
              default:
                  Debug.Log("LOX you missed and fell on your face.");
                  break;

          }*/
    }

    // Update is called once per frame
    void Update()
    {

    }
}
