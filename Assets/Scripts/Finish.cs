using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject cloudPlatform;
    [SerializeField] CoinSpawner coinSpawner;
    public bool levelCompleted { get; private set; }

    private int _requireCoinsAmount = 50;
    private int _requireKeysAmount = 1;
    private int _requireEnemies = 2;

    private int _deathCount;

    // TODO 
    // cut-scene "go home" after chek req.

    private void Update()
    { 
      levelCompleted = PlayerCanPass(); 
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && PlayerCanPass())
        {

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin") || collision.gameObject.CompareTag("Key"))
        {
            Debug.Log("I get item");
            ActivatePlatform(true);
            //play soud
            //start cutscene 
        }
    }

    private bool PlayerCanPass()
    {
        bool isPlayerPass = false;
        switch (SceneManager.GetActiveScene().name)

        {
            case ("Summer"):
                if (Wallet.Instance.KeyCount >= _requireKeysAmount)
                {
                    isPlayerPass = true;
                }
                break;
            case ("Autumn"):
                if (Wallet.Instance.Balance >= _requireCoinsAmount && Wallet.Instance.KeyCount >= _requireKeysAmount)
                {
                    isPlayerPass = true;
                   // ActivatePlatform(isPlayerPass);

                }
                break;
            case ("Winter"):
                if (_requireEnemies>=_deathCount)
                isPlayerPass = true;
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
            coinSpawner.StartCoroutine(coinSpawner.SpawnKeyEnumerator(new Vector2(1, 1), 0, PlayerController.Instance.transform));

        }
    }

    public void CountEnemiesDeaths()
    {
        _deathCount++;
    }
}
