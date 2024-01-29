using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
   [SerializeField] private GameObject keyPrefab;  // The coin prefab to spawn
    [SerializeField] private Transform chestTransform;  // The transform of the chest

    [SerializeField] private float spawnForce = 3f;  // The force at which the coins are spawned
    [SerializeField] private float spawnRadius = 2f;  // The radius within which the coins are randomly spawned

    [SerializeField] private int numCoinsToSpawn = 1;  // The number of coins to spawn

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SpawnCoins();
        }

    }*/

    private void SpawnCoins()
    {
        for (int i = 0; i < numCoinsToSpawn; i++)
        {
            // Calculate a random position within the spawn radius
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;

            // Instantiate the coin prefab at the calculated position
            GameObject coin = Instantiate(keyPrefab, new Vector3(chestTransform.position.x,chestTransform.position.y+1,0), Quaternion.identity);

            // Apply a force to the spawned coin
            
        }
    }
}
