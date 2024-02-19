using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof (Rigidbody2D))]
public class RevisedProjectile : MonoBehaviour
{
    [SerializeField] private float _speed;

   [SerializeField] private Rigidbody2D _rigidbody;
    private ParticleSystem _particle;
   
    private IObjectPool<RevisedProjectile> objectPool;
    // public property to give the projectile a reference to its ObjectPool
    public IObjectPool<RevisedProjectile> ObjectPool { set => objectPool = value; }

    private void Awake()
    {
        _rigidbody=GetComponent<Rigidbody2D>();
        _particle = GetComponent<ParticleSystem>();
       // _rigidbody.AddForce((Vector2.right*_speed),ForceMode2D.Impulse);
    }

    public void SetUpForce(Rigidbody2D rig)
    {
        rig.AddForce((Vector2.one * _speed), ForceMode2D.Impulse);
        
    }

    public void SetUpPosition(Transform weaponTransform)
    {
        gameObject.transform.position = weaponTransform.position;
    }

    
}
