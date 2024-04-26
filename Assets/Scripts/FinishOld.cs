using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishOld : MonoBehaviour
{
    [SerializeField] GameObject cloudPlatform;
    [SerializeField] GameObject weapon;
    private Spawner coinSpawner;
    private Wallet wallet;
    private GameObject player;
    public bool levelCompleted { get; private set; }

    private int _requireCoinsAmount = 0;
    private int _requireKeysAmount = 1;
    private int _requireEnemies = 2;

    public int _deathCount;

    public void Initialize(Wallet wallet,GameObject player)
    {
        this.wallet = wallet;
        this.player = player;
        coinSpawner = GetComponent<Spawner>();
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.K))
       {
         EventBus.OnLevelCompleted(SceneManager.GetActiveScene().buildIndex);
       }
        ThrowTheItem();
    }
    private void OnEnable()
    {
        EventBus.EnemyDeathEvent += CountEnemiesDeaths;

    }
    private void OnDisable()
    {
        EventBus.EnemyDeathEvent -= CountEnemiesDeaths;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        levelCompleted = PlayerCanPass();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //EventBus.OnPlayerCanPass(PlayerCanPass());
            Debug.Log("Check");
          //  Instantiate(weapon, collision.gameObject.transform);
        }

        if (collision.gameObject.CompareTag("Coin") || collision.gameObject.CompareTag("Key"))
        {
            Debug.Log("I get item");
            ActivatePlatform(true);
            
            //start cutscene 
        }
    }

    private bool PlayerCanPass()
    {
        bool isPlayerPass = false;
        switch (SceneManager.GetActiveScene().name)

        {
            case ("Summer"):
                if (wallet.KeyCount >= _requireKeysAmount)
                {
                    isPlayerPass = true;
                    
                }
                break;
            case ("Autumn"):
                if (wallet.Balance >= _requireCoinsAmount && wallet.KeyCount >= _requireKeysAmount)
                {
                    isPlayerPass = true;
                   
                }
                break;
            case ("Winter"):
                if (wallet.Balance >= _requireCoinsAmount)
                { 
                    isPlayerPass = true;
                    
                }
                break;
            default:
                isPlayerPass = false;
                break;

        }
        return isPlayerPass;
    }

    private void ActivatePlatform(bool playerCanPass)
    { 
        var waypointBeh = cloudPlatform.GetComponent<WaypointFollower>();
        waypointBeh.enabled = playerCanPass;
    }

    private void ThrowTheItem()
    {
        if (levelCompleted&& Input.GetKeyDown(KeyCode.C))
        {
            coinSpawner.enabled = true;
            coinSpawner.StartCoroutine(coinSpawner.SpawnItemEnumerator(new Vector2(1, 1),0,player.gameObject.transform,3));

        }
    }

    public void CountEnemiesDeaths()
    {
        _deathCount++;
    }
}
