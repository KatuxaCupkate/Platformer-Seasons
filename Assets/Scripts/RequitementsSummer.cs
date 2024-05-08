using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class RequitementsSummer : RequitementsBase
{
   [SerializeField] private int RequireKeyAmount;
    private string RequireItemTag;

    
    private void Update()
    {
        HaveRequireItems = CheckRequitementsForPassTheLevel(wallet.KeyCount);     
    }
    public override Dictionary<object, object> SetRequitements()
    {
        RequireItemTag = RequireGameObjects.Peek().tag;
       Dictionary<object, object> Requitements =  new Dictionary<object, object>()
        {
            {RequireItemTag, RequireKeyAmount},
        };

        return Requitements;
    }
    public override bool CheckRequitementsForPassTheLevel(object objectValue,object objectName = null )
    {
        return RequitementsToPass.ContainsValue(objectValue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (HaveRequireItems&&collision.CompareTag("Player"))
        {
            RequireGameObjects.TryDequeue(out GameObject result);
            EventBus.OnGetToFinish(result, HaveRequireItems);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Key"))
        {
            EventBus.OnFinishActionTriggered(true);
        }
    }
}
