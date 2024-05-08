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
        SetCoinsView(wallet);
        Wallet = wallet;
       coinsBalanceText = FindAnyObjectByType<Text>();  
       
    }
    private void OnEnable()
    {
        EventBus.ItemPickedUpEvent += ChangeView;
    }

    private void OnDisable()
    {
        EventBus.ItemPickedUpEvent -= ChangeView;
    }
    public void SetCoinsView(Wallet wallet)
    { 
        coinsBalanceText.text="" + wallet.Balance;
    }
    public void ChangeView(string name, int amount)
    {

        if (name.Equals("Key") && amount > 0)
        {
            keyFull.gameObject.SetActive(true);
        }
        else if (name.Equals("Key") && amount <= 0&&Wallet.KeyCount<1)
        { keyFull.gameObject.SetActive(false); }

         amount = Wallet.Balance;

        coinsBalanceText.text = "" + amount;
    }
}
