using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_XPBar : MonoBehaviour
{
    public Image bar;
    public GameObject lvl;
    public GameObject xpManager;

    void OnEnable(){
        if (xpManager == null)
        {
            Debug.LogWarning($"XPManager not choosen");
            return;
        }
        XPManager xpManagerScript = xpManager.GetComponent<XPManager>();
        xpManagerScript.addXPEvent += UpdateBar;
    }

    void OnDisable(){
        if (xpManager == null)
        {
            return;
        }
        XPManager xpManagerScript = xpManager.GetComponent<XPManager>();
        xpManagerScript.addXPEvent -= UpdateBar;
    }

    public void UpdateBar(int newLvl, float progress){
        if (lvl == null)
        {
            Debug.LogWarning($"Lvl Text field is not choosen");
            return;
        }
        lvl.GetComponent<TMP_Text>().text = "lvl " + newLvl.ToString();
        if (bar == null)
        {
            Debug.LogWarning($"Image Bar is not choosen");
            return;
        }
        bar.fillAmount = progress;
    }
}
