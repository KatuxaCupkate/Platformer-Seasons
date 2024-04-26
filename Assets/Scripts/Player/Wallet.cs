using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wallet:MonoBehaviour
{
    private GameDataStorage storageWallet;
    private GameDataWallet dataWallet;
    public int Balance { get; private set; }
    public int KeyCount { get; private set; }
    

    public void Initialize(GameDataWallet data, GameDataStorage dataStorage)
    {    
        storageWallet = dataStorage;
        dataWallet = data;

       Balance = dataWallet.CoinsBalance;
       KeyCount = 0;
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
        SaveCoinsAmount(Balance);
    }

    private void ResetBalanceOnPlayersDeath()
    {
        Balance = 0;
        KeyCount = 0;
        SaveCoinsAmount(Balance);
    }

    public void SaveCoinsAmount(int balance)
    {
        dataWallet.CoinsBalance = balance;
        storageWallet.Save(dataWallet);
    }
}
