using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPManager : MonoBehaviour
{
    private int lvl = 1;
    private int XP = 0;

    public delegate void addXP(int lvl, float progress);
    public event addXP addXPEvent;

    public GameObject server;
    public int XPToNewLvl = 100;

    void OnEnable(){
        if (server == null)
        {
            Debug.LogWarning($"Server not choosen");
            return;
        }
        Server serverScript = server.GetComponent<Server>();
        serverScript.addXPEvent += AddXP;
    }

    void OnDisable(){
        if (server == null)
        {
            return;
        }
        Server serverScript = server.GetComponent<Server>();
        serverScript.addXPEvent -= AddXP;
    }

    private void AddXP(int XPAmount)
    {
        XP += XPAmount;
        while (XP >= XPToNewLvl)
        {
            lvl++;
            XP -= XPToNewLvl;
        }
        if (addXPEvent != null){
            addXPEvent(lvl, 1f * XP / XPToNewLvl);
        }
    }
}
