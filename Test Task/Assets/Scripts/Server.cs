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

    public event AddResources addDiamonds;
    public event AddResources addCoins;
    public event AddResources addBlocks;
    public event AddResources addXP;

    public void AddDiamonds()
    {
        if (diamondsText == null)
        {
            print($"Diamond Text field is not choosen");
            return;
        }
        if (diamondsText.text == "")
        {
            return;
        }
        print(diamondsText.text);
        if (addDiamonds != null)
        {
            addDiamonds(int.Parse(diamondsText.text));
        }
        diamondsText.text = "";
    }

    public void AddCoins()
    {
        if (coinsText == null)
        {
            print($"Coins Text field is not choosen");
            return;
        }
        if (coinsText.text == "")
        {
            return;
        }
        print(coinsText.text);
        if (addCoins != null)
        {
            addCoins(int.Parse(coinsText.text));
        }
        coinsText.text = "";
    }

    public void AddBlocks()
    {
        if (blocksText == null)
        {
            print($"Bolocks Text field is not choosen");
            return;
        }
        if (blocksText.text == "")
        {
            return;
        }
        print(blocksText.text);
        if (addBlocks != null)
        {
            addBlocks(int.Parse(blocksText.text));
        }
        blocksText.text = "";
    }

    public void AddXP()
    {
        if (XPText == null)
        {
            print($"XP Text field is not choosen");
            return;
        }
        if (XPText.text == "")
        {
            return;
        }
        print(XPText.text);
        if (addXP != null)
        {
            addXP(int.Parse(XPText.text));
        }
        XPText.text = "";
    }
}
