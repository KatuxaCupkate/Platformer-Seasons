using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BootstrapGamePlay : MonoBehaviour
{
    [SerializeField] GameDataWallet dataWallet;

    [SerializeField] GameObject Player;
    [SerializeField] GameObject StartPoint;
    [SerializeField] GameObject walletPrefab;
    [SerializeField] CameraController vCamera;
    [SerializeField] Spawner ChestSpawner;
 
    [SerializeField] CollectiblesView coinsView;
   
    [SerializeField] RequitementsBase  requitements;
      
    

    PlayerController playerController;
    PlayerLife playerLife;
    Wallet wallet;
    GameDataStorage dataStorage;
    void Start()
    {
       
        if(dataStorage==null)
        {
          dataStorage = new GameDataStorage();
        }
        dataWallet = dataStorage.Load();

        SetPlayer();
        vCamera.Initialize(Player);

        walletPrefab = Instantiate(walletPrefab);
        wallet = walletPrefab.GetComponent<Wallet>();
        wallet.Initialize(dataWallet,dataStorage);
        coinsView.Initialize(wallet);
        requitements.Initialize(wallet);
        ChestSpawner.Initialize();
      //  spawner[1].Initialize();
      //  finish.Initialize(wallet, Player);
    }

    private void SetPlayer()
    {
        Player = Instantiate(Player, StartPoint.transform.position, Quaternion.identity);
        playerController = Player.GetComponent<PlayerController>();
        playerLife = Player.GetComponent<PlayerLife>();
        playerController.Initialize(Player,true);
        playerLife.Initialize(Player);
    }
}
