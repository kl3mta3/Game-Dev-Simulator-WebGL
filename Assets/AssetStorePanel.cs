using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AssetStorePanel : MonoBehaviour
{
    [SerializeField]
    internal Player player;

    [SerializeField]
    internal float marketingAssetCost;
    [SerializeField]
    internal float marketingBoost;

    [SerializeField]
    internal float designAssetCost;
    [SerializeField]
    internal float designBoost;


    [SerializeField]
    internal float codingAssetCost;
    [SerializeField]
    internal float codingBoost;
    

    [SerializeField]
    internal float modelingAssetCost;
    [SerializeField]
    internal float modelingBoost;

    [SerializeField]
    internal float chanceBad;



    [SerializeField]
    internal TextMeshProUGUI marketingAssetCostText;
    [SerializeField]
    internal TextMeshProUGUI designAssetCostText;
    [SerializeField]
    internal TextMeshProUGUI codingAssetCostText;
    [SerializeField]
    internal TextMeshProUGUI modelingAssetCostText;
    
    public void OnEnable()
    {


        marketingAssetCost = Mathf.Round(marketingAssetCost * (player.playerLevel * 1.5f)+(player.cash*.02f))*10;
        designAssetCost = Mathf.Round(designAssetCost * (player.playerLevel * 1.5f) + (player.cash * .02f)) * 10;
        codingAssetCost = Mathf.Round(codingAssetCost * (player.playerLevel * 1.5f) + (player.cash * .02f)) * 10;
        modelingAssetCost = Mathf.Round(modelingAssetCost * (player.playerLevel * 1.5f) + (player.cash * .02f)) * 10;

        marketingAssetCostText.text ="$"+ marketingAssetCost.ToString();
        designAssetCostText.text = "$" + designAssetCost.ToString();
        codingAssetCostText.text = "$" + codingAssetCost.ToString();
        modelingAssetCostText.text = "$" + modelingAssetCost.ToString();


    }



    public void BuyMarketingAsset()
    {
        if (!IsBadAssettCheck())
        {
            if (player.cash >= marketingAssetCost)
            {
                player.cash -= marketingAssetCost;
                player.marketingSkillBoost += marketingBoost + Mathf.Round(player.playerLevel * 1.5f);
                player.currentGameCost += marketingAssetCost;
            }
        }
        else if (IsBadAssettCheck())
        {
        

            if(player.cash >= marketingAssetCost)
            {
                player.cash -= marketingAssetCost;
                player.marketingSkillBoost -= marketingBoost + Mathf.Round(player.playerLevel * 1.5f);
                player.currentGameCost += marketingAssetCost;
            }



        }
    }
    public void BuyDesignAsset()
    {
        if (!IsBadAssettCheck())
        {
        
            if (player.cash >= designAssetCost)
            {
                player.cash -= designAssetCost;
                player.designSkillBoost += designBoost + Mathf.Round(player.playerLevel * 1.5f);
                player.currentGameCost += designAssetCost;
            }
        }
        else if (IsBadAssettCheck())
        {
            if (player.cash >= designAssetCost)
            {
                player.cash -= designAssetCost;
                player.designSkillBoost -= designBoost + Mathf.Round(player.playerLevel * 1.5f);
                player.currentGameCost += designAssetCost;
            }
        }
    }
    public void BuyCodingAsset()
    {
        if (!IsBadAssettCheck())
        {
        if (player.cash >= codingAssetCost)
        {
            player.cash -= codingAssetCost;
            player.codingSkillBoost += codingBoost + Mathf.Round(player.playerLevel * 1.5f);
            player.currentGameCost += codingAssetCost;
        }
        }
        else if (IsBadAssettCheck())
        {
            if (player.cash >= codingAssetCost)
            {
                player.cash -= codingAssetCost;
                player.codingSkillBoost -= codingBoost + Mathf.Round(player.playerLevel * 1.5f);
                player.currentGameCost += codingAssetCost;
            }
        }
    }
    public void BuyModelingAsset()
    {
        if (!IsBadAssettCheck())
        {
            if (player.cash >= modelingAssetCost)
            {
            player.cash -= modelingAssetCost;
            player.modelingSkillBoost += modelingBoost + Mathf.Round(player.playerLevel * 1.5f);
            player.currentGameCost += modelingAssetCost;
            }
        }
        else if (IsBadAssettCheck())
        {

            if (player.cash >= modelingAssetCost)
            {
                player.cash -= modelingAssetCost;
                player.modelingSkillBoost -= modelingBoost + Mathf.Round(player.playerLevel * 1.5f);
                player.currentGameCost += modelingAssetCost;
            }
        }
    }

    public bool IsBadAssettCheck()
    {

        float change = Random.Range(1,100);
        if (change >= (100-chanceBad))
        {

            return true;
        }
        else
        {
            return false;
        }


    }
}
