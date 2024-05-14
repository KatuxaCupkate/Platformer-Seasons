using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectiblesView : MonoBehaviour
{
    [SerializeField] private Text coinsBalanceText;
    [SerializeField] private RawImage keyEmpty;
    [SerializeField] private RawImage keyFull;
    private Wallet Wallet;

   public void Initialize(Wallet wallet)
    {
       ChangeCoinView(wallet.Balance);
        Wallet = wallet;
       coinsBalanceText = FindAnyObjectByType<Text>();  
       
    }
    private void OnEnable()
    {
        EventBus.ItemPickedUpEvent += ChangeKeyView;
        EventBus.BalanceChangedEvent += ChangeCoinView;
    }

    private void OnDisable()
    {
        EventBus.ItemPickedUpEvent -= ChangeKeyView;
        EventBus.BalanceChangedEvent -= ChangeCoinView;
    }
    
    public void ChangeKeyView(string name, int amount)
    {
        if (name.Equals("Key") && amount > 0)
        {
            keyFull.gameObject.SetActive(true);
        }
        else if (name.Equals("Key") && amount <= 0)
        { keyFull.gameObject.SetActive(false); }
    }
   
   public void ChangeCoinView(int amount)
    {
        coinsBalanceText.text = "" + amount;
    }

}
