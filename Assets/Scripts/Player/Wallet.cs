using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : Singleton<Wallet> 
{
    public int _balance { get; private set; }
    public int _keyCount { get; private set; }
    [SerializeField] CoinsView coinsView;
    // Start is called before the first frame update

    private void Awake()
    {
        EventBus.CoinsBalanceChangedEvent += ChangeBalance;
        EventBus.ItemPickedUpEvent += ChangeKey;
    }

    private void OnDisable()
    {
        EventBus.CoinsBalanceChangedEvent -= ChangeBalance;
        EventBus.ItemPickedUpEvent -= ChangeKey;
    }
    void Start()
    {
        _balance = 0;
        _keyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBalance(int _pickedAmount)
    {
        _balance += _pickedAmount;
        coinsView.ChangeCoinsView(_balance);

    }
    public void ChangeKey(string _name)
    {
        if (_name != "Coin")
            _keyCount++;
        coinsView.ChangeKeyView(_name);
    }
}
