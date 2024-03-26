using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wallet : Singleton<Wallet> 
{
    public int Balance { get; private set; }
    public int KeyCount { get; private set; }

    [SerializeField] CoinsView coinsView;
    // Start is called before the first frame update

    void Start()
    {
        if (Wallet.Instance == null)
        {
            Balance = 0;
            KeyCount = 0;
        }

    }

    private void OnEnable()
    {
        EventBus.ItemPickedUpEvent += ChangeKeyAndCoinBalance;
        EventBus.PlayerDeathEvent += ResetBalanceOnPlayersDeath;
    }

    private void OnDisable()
    {
        EventBus.PlayerDeathEvent -= ResetBalanceOnPlayersDeath;
        EventBus.ItemPickedUpEvent -= ChangeKeyAndCoinBalance;
    }
    
    private void ChangeKeyAndCoinBalance(string name, int amount)
    {
        if (name.Equals("Key"))
        { KeyCount += amount; }
        else if (name.Equals("Coin"))
        { Balance += amount;}
       
    }

    public int SetBalance()
    {
        Wallet.Instance.Balance = Balance;
        return Balance;
    }

    private void ResetBalanceOnPlayersDeath()
    {
        Balance = 0;
        KeyCount = 0;
    }
}
