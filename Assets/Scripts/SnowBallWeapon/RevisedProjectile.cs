using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof (Rigidbody2D))]
public class RevisedProjectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _particle;
  
    private Rigidbody2D _rigidbody;
   
    private IObjectPool<RevisedProjectile> objectPool;
    // public property to give the projectile a reference to its ObjectPool
    public IObjectPool<RevisedProjectile> ObjectPool { set => objectPool = value; }

    private void Awake()
    {
        _rigidbody=GetComponent<Rigidbody2D>();
   
    }

    public void SetUpForce(Rigidbody2D rig,bool isFlipped)
    {
        if (isFlipped)
        {
          rig.AddForce(new Vector2(-1,1)* _speed, ForceMode2D.Impulse);

        }
        else
        {
          rig.AddForce(new Vector2(1, 1) * _speed, ForceMode2D.Impulse);

        }
        
    }


    public void SetUpPosition(Transform weaponTransform)
    {
        gameObject.transform.position = new Vector2 (weaponTransform.position.x, weaponTransform.position.y + 1);
    }

    public void ParticleOn()
    {
        _particle.Play();
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // ParticleOn();
            objectPool.Release(this);
        }
    }

    private void ReleaseSnowBall()
    {
        objectPool.Release(this);
    }
}
