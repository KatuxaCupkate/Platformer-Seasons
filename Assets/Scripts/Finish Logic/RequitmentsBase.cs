using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public abstract class RequitementsBase : MonoBehaviour 
{
    public Dictionary<object, object> RequitementsToPass { get; private set; }
    protected Wallet wallet;
    public bool HaveRequireItems { get; protected set; }
    public Queue<GameObject> RequireGameObjects { get; protected set; } // need to player can pass this objects???

    public int BuildIndex { get; protected set; }
    public virtual void Initialize(Wallet wallet, Queue<GameObject> RequireGameObjects)
    {
        this.wallet= wallet;
        this.RequireGameObjects = RequireGameObjects;
        RequitementsToPass = SetRequitements();
        HaveRequireItems = false;
        BuildIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public abstract Dictionary<object, object> SetRequitements();
    public abstract bool CheckRequitementsForPassTheLevel(object objectValue,object objectName=null );
   
    
}
