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

    public event AddResources addDiamonds;
    public event AddResources addCoins;
    public event AddResources addBlocks;

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
        serverScript.addDiamonds += AddDiamonds;
        serverScript.addCoins += AddCoins;
        serverScript.addBlocks += AddBlocks;
    }

    void OnDisable(){
        if (server == null)
        {
            return;
        }
        Server serverScript = server.GetComponent<Server>();
        serverScript.addDiamonds -= AddDiamonds;
        serverScript.addCoins -= AddCoins;
        serverScript.addBlocks -= AddBlocks;
    }
    private void AddAll(){
        AddDiamonds(addAmount);
        AddCoins(addAmount);
        addBlocks(addAmount);
    }

    public void AddDiamonds(int diamondsAmount)
    {
        diamonds += diamondsAmount;
        if (addDiamonds != null)
        {
            addDiamonds(diamondsAmount);
        }
    }

    public void AddCoins(int coinsAmount)
    {
        coins += coinsAmount;
        if (addCoins != null)
        {
            addCoins(coinsAmount);
        }
    }

    public void AddBlocks(int blocksAmount)
    {
        blocks += blocksAmount;
        if (addBlocks != null)
        {
            addBlocks(blocksAmount);
        }
    }
}
