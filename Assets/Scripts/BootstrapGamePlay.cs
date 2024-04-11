using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BootstrapGamePlay : MonoBehaviour
{
    [SerializeField] GameDataWallet dataWallet;

    [SerializeField] GameObject Player;
    [SerializeField] GameObject StartPoint;
    [SerializeField] Wallet wallet;
    [SerializeField] CameraController vCamera;
    [SerializeField] Spawner [] spawner;
    [SerializeField] CollectiblesView coinsView;
    [SerializeField] Finish finish;


    PlayerController playerController;
    PlayerLife playerLife;
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

        wallet = Instantiate(wallet);
        wallet.Initialize(dataWallet,dataStorage);

        coinsView.Initialize(wallet);

        spawner[0].Initialize();
        spawner[1].Initialize();
        finish.Initialize(wallet, Player);
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
