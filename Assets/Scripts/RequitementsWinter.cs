using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequitementsWinter : RequitementsAutumn
{
    [SerializeField] private int ReqEnemyCount;

    private const string requestName = "Enemy Deaths";

    private int _deathCounter = 0;

    private void Update()
    {
        if (gameObject.CompareTag("NPC"))
        {
            HaveRequireItems = CheckRequitementsForPassTheLevel(wallet.Balance, Coins.tag);
            //activate weapon
        }
        else if (gameObject.CompareTag("Home"))
        {
            HaveRequireItems = CheckRequitementsForPassTheLevel(wallet.KeyCount, Key.tag);

        }

      
    }
    private void OnEnable()
    {
        EventBus.EnemyDeathEvent += CountEnemiesDeaths;

    }
    private void OnDisable()
    {
        EventBus.EnemyDeathEvent -= CountEnemiesDeaths;

    }
    public override bool CheckRequitementsForPassTheLevel(object objectValue, object objectName = null)
    {
        return base.CheckRequitementsForPassTheLevel(objectValue, objectName);
    }

    public override Dictionary<object, object> SetRequitements()
    {
        Dictionary<object, object> result = base.SetRequitements();
        result.Add(requestName, ReqEnemyCount);
        return result;
    }

    public void CountEnemiesDeaths()
    {
        _deathCounter++;
         if(CheckRequitementsForPassTheLevel(_deathCounter, requestName))
        {
           EventBus.OnAllEnemiesDead();
            
        }
    }

    
}
