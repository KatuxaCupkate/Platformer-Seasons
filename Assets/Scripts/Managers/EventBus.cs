using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public static class EventBus 
{
    public delegate void OnCoinsBalanceChanged(int _amount);
    public static Action<int> BalanceChangedEvent;

    public static Action LevelRestartedEvent;
    public static Action AllEnemiesDeadEvent;
    public static Action<bool> FinishActionTriggerEvent;

    public static Action<int> LevelCompletedEvent;
    public static Action<GameObject,bool> PlayerGetToFinishEvent;
    public static Action ItemThrownEvent;
    public static Action PlayerDeathEvent;
    public static Action EnemyDeathEvent;
    public static Action EnemyGetDamageEvent;
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
        BalanceChangedEvent?.Invoke(_amount);
    }
    public static void OnPlayerDeathEvent()
    {
        PlayerDeathEvent?.Invoke();
    }

    public static void OnEnemyDeathEvent()
    {
        EnemyDeathEvent?.Invoke();
    }

   public static void OnEnemyGetDamage()
    {
        EnemyGetDamageEvent?.Invoke();
    }

    public static void OnLevelRestarted()
    {
        LevelRestartedEvent?.Invoke();
    }


    public static void OnLevelCompleted(int sceneIndex)
    {
        LevelCompletedEvent ?.Invoke(sceneIndex);
    }

    public static void OnGetToFinish(GameObject reqItem,bool canPass)
    {
        PlayerGetToFinishEvent?.Invoke(reqItem,canPass);
    }

    public static void OnFinishActionTriggered(bool isNPC)
    {
        FinishActionTriggerEvent?.Invoke(isNPC);
    }
     
    public static void OnAllEnemiesDead()
    {
        AllEnemiesDeadEvent?.Invoke();
    }

    public static void OnItemThrown()
    {
        ItemThrownEvent?.Invoke();
    }
}
