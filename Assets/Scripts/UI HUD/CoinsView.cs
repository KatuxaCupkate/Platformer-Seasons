using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsView : Singleton<CoinsView>
{
    [SerializeField] private Text coinsBalanceText;
  
    [SerializeField] private RawImage keyEmpty;
    [SerializeField] private RawImage keyFull;

    private void Start()
    {

        if (Wallet.Instance != null)
        {
       
            SetCoinsView(Wallet.Instance.SetBalance());
        }
        if (coinsBalanceText == null)
        {
            coinsBalanceText = Instance.coinsBalanceText;
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

        if (name.Equals("Key") && amount > 0)
        {
            keyFull.gameObject.SetActive(true);
        }
        else if (name.Equals("Key") && amount <= 0)
        { keyFull.gameObject.SetActive(false); }

         amount = Wallet.Instance.Balance;

        coinsBalanceText.text = "" + amount;
    }
}
