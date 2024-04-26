using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public abstract class RequitementsBase : MonoBehaviour 
{
    public Dictionary<object, object> RequitementsToPass { get; private set; }
    private Wallet Wallet;
    public int LevelBuildIndex { get; private set; }
    public bool HaveRequireItems { get; protected set; }

    public virtual void Initialize(Wallet wallet)
    {
        RequitementsToPass = SetRequitements();
        LevelBuildIndex = SceneManager.GetActiveScene().buildIndex;
        HaveRequireItems = false;
        Wallet=wallet;
    }
    public abstract Dictionary<object, object> SetRequitements();
    public abstract bool CheckRequitementsForPassTheLevel(object objectValue,object objectName=null );
   
    
}
