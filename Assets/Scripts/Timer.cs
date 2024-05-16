using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    private GameDataStorage storageWallet;
    private GameDataWallet dataWallet;


         private float elapsedTime = 0f;

     public void Initialize( GameDataStorage storageWallet, GameDataWallet dataWallet)
     {
           this.storageWallet = storageWallet;
           this.dataWallet = dataWallet;
           elapsedTime = dataWallet.elapsedTime;
     }
    void Update()
    {
        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        string minutesString = minutes < 10 ? "0" + minutes.ToString() : minutes.ToString();
        string secondsString = seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();

        timerText.text = minutesString + ":" + secondsString;
        SaveElapsedTime(elapsedTime);
    }

    private void OnEnable() {
       // EventBus.PlayerDeathEvent += ResetTimer;
    }

    private void OnDisable() {
        
       // EventBus.PlayerDeathEvent -= ResetTimer;
    }

    private void ResetTimer()
    {
       elapsedTime = 0f;
    }

    public void SaveElapsedTime(float elapsedTime)
    {
        dataWallet.elapsedTime = elapsedTime;
        storageWallet.Save(dataWallet);
    }
}
