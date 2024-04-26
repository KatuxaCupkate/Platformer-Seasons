using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequitementsAutumn : RequitementsBase
{
    [SerializeField] private int RequiringCoinCount;
    [SerializeField] private int RequiredKeyCount;
   
    private const string CoinsName = "Coin";
    private const string KeyName = "Key";
    private Wallet wallet;

    public override void Initialize(Wallet wallet)
    {
        base.Initialize(wallet);
        this.wallet = wallet;
    }

    private void Update()
    {
        if (HaveRequireItems)
        {
            EventBus.OnGetToFinish(HaveRequireItems);
        }
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
        object CoinKey = CoinsName;
        object CoinValue = RequiringCoinCount;
        object KeyValue = RequiredKeyCount;
        object KeysKey = KeyName;
        Dictionary<object, object> result = new Dictionary<object, object>()
        {
           { CoinKey,CoinValue},
           {KeysKey,KeyValue},
        };
        return result;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.CompareTag("NPC"))
        {
           
            HaveRequireItems = CheckRequitementsForPassTheLevel(wallet.Balance, CoinsName);
           
        }
        else if (gameObject.CompareTag("Home"))
        {
            HaveRequireItems = CheckRequitementsForPassTheLevel(wallet.KeyCount, KeyName);
        }
    }
}
