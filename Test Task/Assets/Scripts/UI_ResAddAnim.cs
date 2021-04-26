using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_ResAddAnim : MonoBehaviour
{
    public GameObject resourceManager;
    public TMP_Text diamonds;
    public TMP_Text coins;
    public TMP_Text blocks;

    public TMP_Text diamondsAnim;
    public TMP_Text coinsAnim;
    public TMP_Text blocksAnim;

    void OnEnable(){
        if (resourceManager == null)
        {
            Debug.LogWarning($"Resource Manager not choosen");
            return;
        }
        ResourcesManager resourcesManagerScript = resourceManager.GetComponent<ResourcesManager>();
        resourcesManagerScript.addBlocks += AnimAddBlocks;
        resourcesManagerScript.addCoins += AnimAddCoins;
        resourcesManagerScript.addDiamonds += AnimAddDiamonds;
    }

    void OnDisable(){
        if (resourceManager == null)
        {
            return;
        }
        ResourcesManager resourcesManagerScript = resourceManager.GetComponent<ResourcesManager>();
        resourcesManagerScript.addBlocks -= AnimAddBlocks;
        resourcesManagerScript.addCoins -= AnimAddCoins;
        resourcesManagerScript.addDiamonds -= AnimAddDiamonds;
    }

    public void AnimAddDiamonds(int amount){
        diamonds.text = (int.Parse(diamonds.text) + amount).ToString();
        diamondsAnim.text = amount.ToString();
        if (amount >= 0) {
            diamondsAnim.GetComponent<Animation>().Play("AddResourceAnim");
        } else {
            diamondsAnim.GetComponent<Animation>().Play("MinResourceAnim");
        }
    }

    public void AnimAddCoins(int amount){
        coins.text = (int.Parse(coins.text) + amount).ToString();
        coinsAnim.text = amount.ToString();
        if (amount >= 0) {
            coinsAnim.GetComponent<Animation>().Play("AddResourceAnim");
        } else {
            coinsAnim.GetComponent<Animation>().Play("MinResourceAnim");
        }
    }

    public void AnimAddBlocks(int amount){
        blocks.text = (int.Parse(blocks.text) + amount).ToString();
        blocksAnim.text = amount.ToString();
        if (amount >= 0) {
            blocksAnim.GetComponent<Animation>().Play("AddResourceAnim");
        } else {
            blocksAnim.GetComponent<Animation>().Play("MinResourceAnim");
        }
    }
}
