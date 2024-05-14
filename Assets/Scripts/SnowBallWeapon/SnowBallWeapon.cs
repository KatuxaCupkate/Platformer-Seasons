using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SnowBallWeapon : MonoBehaviour

{
    private IObjectPool<RevisedProjectile> objectPool;
    // throw an exception if we try to return an existing item, already in the pool

    private SpriteRenderer spriteRenderer;

    [SerializeField] private bool collectionCheck = true;
    // extra options to control the pool capacity and maximum size
    [SerializeField] private int defaultCapacity = 5;
    [SerializeField] private int maxSize = 10;
    [SerializeField] private RevisedProjectile projectilePrefab;
    private void Awake()
    {
        objectPool = new ObjectPool<RevisedProjectile>(CreateProjectile,
        OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
        collectionCheck, defaultCapacity, maxSize);
                             
    }
   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Fire();
        }
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

    private void Fire()
    {
        objectPool.Get();
        EventBus.OnItemThrown();
    }

    public void ActivateTheWeapon(bool activate)
    {
      gameObject.SetActive(activate);
    }
}
