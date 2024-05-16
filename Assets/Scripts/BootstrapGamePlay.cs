using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class BootstrapGamePlay : MonoBehaviour
{
    [SerializeField] GameDataWallet dataWallet;
     [SerializeField] Timer timer;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject StartPoint;
    [SerializeField] GameObject WalletPref;
    [SerializeField] CameraController vCamera;
    [SerializeField] Spawner ChestSpawner;
 
    [SerializeField] CollectiblesView coinsView;
   
    [SerializeField] List<RequitementsBase> requitements;
    [SerializeField] List<GameObject> RequireGameObjectsList;
    [SerializeField] Dialogue NPCDialogue;
   [SerializeField] FinishActions finishActions;


    public Queue<GameObject> RequireGameObjectsQueue;
    PlayerController playerController;
    PlayerLife playerLife;
    Wallet Wallet;
    GameDataStorage dataStorage;

    private void Awake()
    {
       
    }
    void Start()
    {
        RequireGameObjectsQueue = new Queue<GameObject>();
        foreach (var item in RequireGameObjectsList)
        {
           RequireGameObjectsQueue.Enqueue(item);
        }

        SetData();
        SetPlayer();
        timer.Initialize(dataStorage,dataWallet);
        vCamera.Initialize(Player);
        Wallet = Instantiate(WalletPref).GetComponent<Wallet>();
        Wallet.Initialize(dataWallet,dataStorage);
        coinsView.Initialize(Wallet);

        SetRequitements();

        ChestSpawner.Initialize();
        NPCDialogue.Initialize(requitements[0]);
        finishActions.Initialize(Player, vCamera);
    }

    private void SetPlayer()
    {
        Player = Instantiate(Player, StartPoint.transform.position, Quaternion.identity);
        playerController = Player.GetComponent<PlayerController>();
        playerLife = Player.GetComponent<PlayerLife>();
        playerController.Initialize(Player,true);
        playerLife.Initialize(Player);
    }

    private void SetData()
    {
        if (dataStorage == null)
        {
            dataStorage = new GameDataStorage();
        }
        dataWallet = dataStorage.Load();
    }

    private void SetRequitements()
    {
        foreach (var item in requitements)
        {
            item.Initialize(Wallet, RequireGameObjectsQueue);
        }
    }
}
