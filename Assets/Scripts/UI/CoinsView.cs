using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsView : Singleton<CoinsView>
{
    [SerializeField] private Text coinsBalanceText;

    [SerializeField] private Text key;
    [SerializeField]  Wallet wallet;
    public void ChangeCoinsView(int _balance)
    {
        if (coinsBalanceText == null)
        {
            coinsBalanceText = Instance.coinsBalanceText;
        }

        coinsBalanceText.text="" + _balance;

    }
    public void ChangeKeyView(string name)
    {
        if(key==null)
        {
            key = Instance.key;
        }
        if (name!="Coin")
        key.text = name +" "+ wallet._keyCount;
    }
}
