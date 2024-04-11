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
        StartCoroutine(SpawnItemEnumerator(_direction, _waitForSec,_transform));
    }
    public IEnumerator SpawnItemEnumerator(Vector2 direction, float waitSec, Transform transform)
    {
        yield return new WaitForSeconds(waitSec);
        var key = Instantiate(itemPrefab, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        var keyRig= key.GetComponent<Rigidbody2D>();
        keyRig.AddForce(direction * _impulseForce, ForceMode2D.Impulse);

    }

    private void SetForSpawnFromChest()
    {
        _transform = GetComponent<Transform>();
        _impulseForce = 3;
        _waitForSec = 0.7f;
        _direction = new Vector2(-1, 1);
    }
}
