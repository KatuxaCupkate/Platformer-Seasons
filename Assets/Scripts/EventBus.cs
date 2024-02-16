using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mono.Cecil;


public static class EventBus 
{
    public delegate void OnCoinsBalanceChanged(int _amount);
    public static event OnCoinsBalanceChanged CoinsBalanceChangedEvent;

    public static Action PlayerDeathEvent;
    public static Action ChestIsOpenEvent;
    public static Action <string,int> ItemPickedUpEvent ;

    public static void OnItemPickedUpEvent(string itemName, int amount)
    {
        ItemPickedUpEvent?.Invoke(itemName,amount);
    }

    public static void OnChestIsOpenEvent()
    {
        ChestIsOpenEvent?.Invoke();
    }

   public static void OnBalanceChangedEvent(int _amount)

    {
        CoinsBalanceChangedEvent?.Invoke(_amount);
    }
    public static void OnPlayerDethEvent()
    {
        PlayerDeathEvent?.Invoke();
    }
}
