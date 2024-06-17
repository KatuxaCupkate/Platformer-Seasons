using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.InputSystem;

public class SnowBallWeapon : MonoBehaviour

{
    private IObjectPool<RevisedProjectile> objectPool;
    // throw an exception if we try to return an existing item, already in the pool

    [SerializeField] private bool collectionCheck = true;
    // extra options to control the pool capacity and maximum size
    [SerializeField] private int defaultCapacity = 5;
    [SerializeField] private int maxSize = 10;
    [SerializeField] private RevisedProjectile projectilePrefab;

    private NewControls _controls;
    private void Awake()
    {
        objectPool = new ObjectPool<RevisedProjectile>(CreateProjectile,
        OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
        collectionCheck, defaultCapacity, maxSize);

        _controls = new NewControls();
        _controls.Enable();
                             
    }
   
    private void OnEnable()
    {
        _controls.GamePlay.Fire.performed += Fire;
    }

    private void OnDisable()
    {
        _controls.GamePlay.Fire.performed -= Fire;
    }

    // invoked when creating an item to populate the object pool
    private RevisedProjectile CreateProjectile()
    {
        RevisedProjectile projectileInstance = Instantiate(projectilePrefab);
        projectileInstance.ObjectPool = objectPool;
        return projectileInstance;
    }
    // invoked when returning an item to the object pool
    public void OnReleaseToPool(RevisedProjectile pooledObject)
    {
       
        pooledObject.gameObject.SetActive(false);
       
    }
    // invoked when retrieving the next item from the object pool
    private void OnGetFromPool(RevisedProjectile pooledObject)
    {
        pooledObject.SetUpPosition(gameObject.transform);
        pooledObject.gameObject.SetActive(true);
        pooledObject.SetUpForce(pooledObject.GetComponent<Rigidbody2D>(),gameObject.GetComponent<SpriteRenderer>().flipX);
    }
    // invoked when we exceed the maximum number of pooled items (i.e. destroy the pooled object)
    private void OnDestroyPooledObject(RevisedProjectile pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        objectPool.Get();
        EventBus.OnItemThrown();
    }

   
}
