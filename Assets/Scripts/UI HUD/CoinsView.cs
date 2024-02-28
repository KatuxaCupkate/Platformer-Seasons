using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class CoinsView : Singleton<CoinsView>
{
    [SerializeField] private Text coinsBalanceText;
    [SerializeField] private Text key;

    private void Start()
    {

        if (Wallet.Instance != null)
        {
       
            SetCoinsView(Wallet.Instance.SetBalance());
        }
       
    }
    private void OnEnable()
    {
       // EventBus.CoinsBalanceChangedEvent += ChangeCoinsView;
        EventBus.ItemPickedUpEvent += ChangeView;
    }

    private void OnDisable()
    {
       // EventBus.CoinsBalanceChangedEvent -= ChangeCoinsView;
        EventBus.ItemPickedUpEvent -= ChangeView;
    }
    public void SetCoinsView(int balance)
    {
       balance = Wallet.Instance.Balance;
        if (coinsBalanceText == null)
        {
            coinsBalanceText = Instance.coinsBalanceText;
        }

        coinsBalanceText.text="" + balance;
    }
    public void ChangeView(string name, int amount)
    {
       amount = Wallet.Instance.Balance;

        if(key==null)
        {
            key = Instance.key;
        }

        if (name.Equals("Key"))
        {
           key.text = Wallet.Instance.KeyCount.ToString();

        }
        if (coinsBalanceText == null)
        {
            coinsBalanceText = Instance.coinsBalanceText;
        }

        coinsBalanceText.text = "" + amount;
    }
}
