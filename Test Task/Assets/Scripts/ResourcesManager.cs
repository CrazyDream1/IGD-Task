using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResourcesManager : MonoBehaviour
{
    private int diamonds = 0;
    private int coins = 0;
    private int blocks = 0;
    [SerializeField]
    private int addAmount;
    [SerializeField]
    private float addTime;

    public GameObject server;
    
    public delegate void AddResources(int amount);

    public event AddResources addDiamondsEvent;
    public event AddResources addCoinsEvent;
    public event AddResources addBlocksEvent;

    void Start()
    {
        InvokeRepeating("AddAll", addTime, addTime);
    }

    void OnEnable(){
        if (server == null)
        {
            Debug.LogWarning($"Server not choosen");
            return;
        }
        Server serverScript = server.GetComponent<Server>();
        serverScript.addDiamondsEvent += AddDiamonds;
        serverScript.addCoinsEvent += AddCoins;
        serverScript.addBlocksEvent += AddBlocks;
    }

    void OnDisable(){
        if (server == null)
        {
            return;
        }
        Server serverScript = server.GetComponent<Server>();
        serverScript.addDiamondsEvent -= AddDiamonds;
        serverScript.addCoinsEvent -= AddCoins;
        serverScript.addBlocksEvent -= AddBlocks;
    }
    private void AddAll(){
        addDiamondsEvent(addAmount);
        addCoinsEvent(addAmount);
        addBlocksEvent(addAmount);
    }

    public void AddDiamonds(int diamondsAmount)
    {
        diamonds += diamondsAmount;
        if (addDiamondsEvent != null)
        {
            addDiamondsEvent(diamondsAmount);
        }
    }

    public void AddCoins(int coinsAmount)
    {
        coins += coinsAmount;
        if (addCoinsEvent != null)
        {
            addCoinsEvent(coinsAmount);
        }
    }

    public void AddBlocks(int blocksAmount)
    {
        blocks += blocksAmount;
        if (addBlocksEvent != null)
        {
            addBlocksEvent(blocksAmount);
        }
    }
}
