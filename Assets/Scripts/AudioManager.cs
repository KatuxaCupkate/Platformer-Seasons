using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource[] collectedAudio;
    [SerializeField] private AudioSource _enemyDeadAudio;
    [SerializeField] private AudioSource _enemyDamageAudio;
    private const string _keyName = "Key";
    private const string _coinName = "Coin";
    private const string _chestName = "Chest";


    private void OnEnable()
    {
        EventBus.ItemPickedUpEvent += PlayItemAudio;
        EventBus.EnemyDeathEvent += PlayEnemyDeadAudio;
        EventBus.EnemyGetDamageEvent += PlayEnemyDamageAudio;
    }

    private void OnDisable()
    {
        EventBus.EnemyGetDamageEvent -= PlayEnemyDamageAudio;
        EventBus.EnemyDeathEvent -= PlayEnemyDeadAudio;
        EventBus.ItemPickedUpEvent -= PlayItemAudio;
    }
    public void PlayItemAudio(string name, int amount)
    {
        switch (name)
        {

            case _keyName:
                collectedAudio[0].Play();
                break;
            case _coinName:
                collectedAudio[1].Play();
                break;
            case _chestName:
                collectedAudio[2].Play();
                break;
            default:
                break;
           
        }
    }


    private void PlayEnemyDeadAudio()
    {
            _enemyDeadAudio.Play();
    }
    
    private void PlayEnemyDamageAudio()
    {
        _enemyDamageAudio.Play();
    }
}
