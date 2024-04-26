using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class RequitementsSummer : RequitementsBase
{
   [SerializeField] private int RequireKeyAmount;
   [SerializeField] private string RequireItemName;

   private Wallet wallet;
 
  
    public override void Initialize(Wallet wallet)
    {
        base.Initialize(wallet);
        this.wallet = wallet;
    }

    private void Update()
    {
        HaveRequireItems = CheckRequitementsForPassTheLevel(wallet.KeyCount);
        if(HaveRequireItems)
        {
            EventBus.OnGetToFinish(HaveRequireItems);
        }

    }
    public override Dictionary<object, object> SetRequitements()
    {
        object name = RequireItemName;
        object value = RequireKeyAmount;
       Dictionary<object, object> Requitements =  new Dictionary<object, object>()
        {
            {name, value},
        };

        return Requitements;
    }
    public override bool CheckRequitementsForPassTheLevel(object objectValue,object objectName = null )
    {
        return RequitementsToPass.ContainsValue(objectValue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
  
}
