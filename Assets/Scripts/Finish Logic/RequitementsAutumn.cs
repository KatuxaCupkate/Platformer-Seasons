using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequitementsAutumn : RequitementsBase
{
    [SerializeField] private int CoinCount;
    [SerializeField] public int RequiringCoinCount { get;  private set ; }
    [SerializeField] private int RequiredKeyCount;

    protected GameObject Coins;
    protected GameObject Key;
    private void Awake()
    {
        RequiringCoinCount = CoinCount;
    }
    private void Update()
    {
        // if (gameObject.CompareTag("NPC"))
        // {
        //     HaveRequireItems = CheckRequitementsForPassTheLevel(wallet.Balance, Coins.tag);
        // }
        // else if (gameObject.CompareTag("Home"))
        // {
        //     HaveRequireItems = CheckRequitementsForPassTheLevel(wallet.KeyCount, Key.tag);

        // }
    }
    public override bool CheckRequitementsForPassTheLevel(object objectValue, object objectName )
    {
        foreach (KeyValuePair<object , object> kvp in RequitementsToPass)
        {
            
            if (kvp.Key.Equals(objectName))
            {
                return (int)kvp.Value<=(int)objectValue;
            }
            else
                continue;
        }
        return false;
    }

    public override Dictionary<object, object> SetRequitements()
    {
       var items = RequireGameObjects.ToArray();
        Coins = items[0]; Key = items[1];
        Dictionary<object, object> result = new Dictionary<object, object>()
        {
           { Coins.tag,RequiringCoinCount},
           {Key.tag,RequiredKeyCount},
        };
        return result;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.CompareTag("NPC")&&CheckRequitementsForPassTheLevel(wallet.Balance, Coins.tag))
        {
             HaveRequireItems = CheckRequitementsForPassTheLevel(wallet.Balance, Coins.tag);
            EventBus.OnGetToFinish(Coins, CheckRequitementsForPassTheLevel(wallet.Balance, Coins.tag));
        }
        else if (gameObject.CompareTag("Home") && CheckRequitementsForPassTheLevel(wallet.KeyCount, Key.tag))
        {
            HaveRequireItems = CheckRequitementsForPassTheLevel(wallet.KeyCount, Key.tag);
           EventBus.OnGetToFinish(Key, CheckRequitementsForPassTheLevel(wallet.KeyCount, Key.tag));  
        }

    }
    
}
