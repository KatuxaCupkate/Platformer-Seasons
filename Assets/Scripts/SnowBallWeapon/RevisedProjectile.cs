using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof (Rigidbody2D))]
public class RevisedProjectile : MonoBehaviour
{
    [SerializeField] private float _speed;

   [SerializeField] private Rigidbody2D _rigidbody;
   private SnowBallWeapon weapon;
   private ParticleSystem _particle;
   
    private IObjectPool<RevisedProjectile> objectPool;
    // public property to give the projectile a reference to its ObjectPool
    public IObjectPool<RevisedProjectile> ObjectPool { set => objectPool = value; }

    private void Awake()
    {
        _rigidbody=GetComponent<Rigidbody2D>();
        _particle = GetComponentInChildren<ParticleSystem>();
        weapon = FindAnyObjectByType<SnowBallWeapon>();
      
    }

    public void SetUpForce(Rigidbody2D rig,bool isFliped)
    {
        if (isFliped)
        {
          rig.AddForce(new Vector2 (-1,1)* _speed,ForceMode2D.Impulse);

        }
        else
        {
          rig.AddForce((Vector2.one * _speed), ForceMode2D.Impulse);

        }
        
    }

    public void SetUpPosition(Transform weaponTransform)
    {
        gameObject.transform.position = weaponTransform.position;
    }

    public void ParticleOn()
    {
        _particle.Play();
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Invoke("ReleaseSnowBall", 0.2f);
        }
    }

    private void ReleaseSnowBall()
    {
        objectPool.Release(this);
    }
}
