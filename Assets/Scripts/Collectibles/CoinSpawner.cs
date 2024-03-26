using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;  // The item prefab to spawn
    private Transform _transform;  // The transform of the chest
    private int _impulseForce = 3;
    private float _waitForSec;
    private Vector2 _direction;
    //[SerializeField] private float spawnForce = 3f;  // The force at which the coins are spawned
    // [SerializeField] private int numCoinsToSpawn = 1;  // The number of coins to spawn


    private void Start()
    {
        _transform = GetComponent<Transform>();
        // Set for spawn from chest
        _impulseForce = 3;
        _waitForSec = 0.7f;
        _direction = new Vector2(-1, 1);
    }

    private void OnEnable()
    {
        EventBus.ChestIsOpenEvent += SpawnKey;
    }

    private void OnDisable()
    {
        EventBus.ChestIsOpenEvent -= SpawnKey;
    }

    private void SpawnKey()
    {
        StartCoroutine(SpawnKeyEnumerator(_direction, _waitForSec,_transform));
    }
    public IEnumerator SpawnKeyEnumerator(Vector2 direction, float waitSec, Transform transform)
    {
        yield return new WaitForSeconds(waitSec);
        var key = Instantiate(itemPrefab, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        key.TryGetComponent<Rigidbody2D>(out Rigidbody2D keyRig);
        keyRig.AddForce(direction * _impulseForce, ForceMode2D.Impulse);

    }
}
