using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class Server : MonoBehaviour
{
    public TMP_InputField diamondsText;
    public TMP_InputField coinsText;
    public TMP_InputField blocksText;
    public TMP_InputField XPText;

    public delegate void AddResources(int amount);

    public event AddResources addDiamondsEvent;
    public event AddResources addCoinsEvent;
    public event AddResources addBlocksEvent;
    public event AddResources addXPEvent;

    public void AddDiamonds()
    {
        if (diamondsText == null)
        {
            Debug.LogWarning($"Diamond Text field is not choosen");
            return;
        }
        if (diamondsText.text == "")
        {
            return;
        }
        if (addDiamondsEvent != null)
        {
            addDiamondsEvent(int.Parse(diamondsText.text));
        }
        diamondsText.text = "";
    }

    public void AddCoins()
    {
        if (coinsText == null)
        {
            Debug.LogWarning($"Coins Text field is not choosen");
            return;
        }
        if (coinsText.text == "")
        {
            return;
        }
        if (addCoinsEvent != null)
        {
            addCoinsEvent(int.Parse(coinsText.text));
        }
        coinsText.text = "";
    }

    public void AddBlocks()
    {
        if (blocksText == null)
        {
            Debug.LogWarning($"Bolocks Text field is not choosen");
            return;
        }
        if (blocksText.text == "")
        {
            return;
        }
        if (addBlocksEvent != null)
        {
            addBlocksEvent(int.Parse(blocksText.text));
        }
        blocksText.text = "";
    }

    public void AddXP()
    {
        if (XPText == null)
        {
            Debug.LogWarning($"XP Text field is not choosen");
            return;
        }
        if (XPText.text == "")
        {
            return;
        }
        if (addXPEvent != null)
        {
            addXPEvent(int.Parse(XPText.text));
        }
        XPText.text = "";
    }
}
