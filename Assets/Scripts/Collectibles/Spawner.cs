using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab; 
    private Transform _transform; 
    private int _impulseForce;
    private float _waitForSec;
    private Vector2 _direction;
   

    public void Initialize()
    {
        SetForSpawnFromChest();
    }

    private void OnEnable()
    {
        EventBus.ChestIsOpenEvent += SpawnItem;
    }

    private void OnDisable()
    {
        EventBus.ChestIsOpenEvent -= SpawnItem;
    }

    private void SpawnItem()
    {
        Instantiate(itemPrefab, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(_direction * _impulseForce, ForceMode2D.Impulse);
    }
    public IEnumerator SpawnItemEnumerator(Vector2 direction, float waitSec, Transform transform,int force)
    {
       var clone = Instantiate(itemPrefab, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        yield return new WaitForSeconds(waitSec);
      
       
    }

    private void SetForSpawnFromChest()
    {
        _transform = GetComponent<Transform>();
        _impulseForce = 3;
        _waitForSec = 0.7f;
        _direction = new Vector2(-1, 1);
    }
}
