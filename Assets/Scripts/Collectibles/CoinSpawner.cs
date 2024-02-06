using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
   [SerializeField] private GameObject itemPrefab;  // The coin prefab to spawn
   private Transform _chestTransform;  // The transform of the chest

    //[SerializeField] private float spawnForce = 3f;  // The force at which the coins are spawned
    // [SerializeField] private int numCoinsToSpawn = 1;  // The number of coins to spawn


    private void Start()
    {
        _chestTransform = GetComponent<Transform>();
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
        StartCoroutine(SpawnKeyEnumerator());
    }
    private IEnumerator SpawnKeyEnumerator()
    {
        yield return new WaitForSeconds(1f);
         Instantiate(itemPrefab, new Vector3(_chestTransform.position.x,_chestTransform.position.y+1,0), Quaternion.identity);
           
    }
}
