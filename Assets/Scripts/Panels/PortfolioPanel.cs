using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PortfolioPanel : MonoBehaviour
{
    [SerializeField]
    internal Player player;

    [SerializeField]
    internal PortfolioPrefab[] portfolioPrefabs;


    public void OnEnable()
    {
        if (player.gamePortfolio.Count >= 1)
        {
            SetPanels();
        }
    }


    public void OnDisable()
    {
        ResetPanels();
    }

    public void SetPanels()
    {


            foreach (PortfolioPrefab _prefab in portfolioPrefabs)
            {
                _prefab.gameObject.SetActive(true);


            }

            for (int t = (player.gamePortfolio.Count); t < player.gamePortfolio.Count-10; t--)
            {

                if (player.gamePortfolio[t].name != "" || player.gamePortfolio[t].name != null)
                {
                     portfolioPrefabs[t].gameNameText.text = player.gamePortfolio[t].name;
                     portfolioPrefabs[t].gameProfitText.text = "$"+player.gamePortfolio[t].cashMadeToDate.ToString();
                     portfolioPrefabs[t].gameCostText.text = "$" + player.gamePortfolio[t].costToDate.ToString();
                     portfolioPrefabs[t].unitsSoldText.text = player.gamePortfolio[t].totalUnitsSold.ToString();
                     portfolioPrefabs[t].popularityText.text = player.gamePortfolio[t].popularity.ToString()+"/5 Stars";


                     portfolioPrefabs[t].steem.isOn = player.gamePortfolio[t].onSteem;
                     portfolioPrefabs[t].epik.isOn = player.gamePortfolio[t].onEpik;
                     portfolioPrefabs[t].pear.isOn = player.gamePortfolio[t].onPear;
                     portfolioPrefabs[t].cyborg.isOn = player.gamePortfolio[t].onCyborg;
                     portfolioPrefabs[t].playBox.isOn = player.gamePortfolio[t].onPlayBox;
                     portfolioPrefabs[t].xStation.isOn = player.gamePortfolio[t].onXStation;
                     portfolioPrefabs[t].gameObject.SetActive(true);
                }
                else
                {
                    portfolioPrefabs[t].gameObject.SetActive(false);
                }

            

        }

    }


    public void ResetPanels()
    {

        foreach (PortfolioPrefab prefab in portfolioPrefabs)
        {
            prefab.gameNameText.text = "";
            prefab.gameProfitText.text = "";
            prefab.gameCostText.text = "$" +  "";
            prefab.unitsSoldText.text = "";
            prefab.popularityText.text = ""; ;

            
            prefab.steem.isOn = false;
            prefab.epik.isOn = false;
            prefab.pear.isOn = false;
            prefab.cyborg.isOn = false;
            prefab.playBox.isOn = false;
            prefab.xStation.isOn = false;

            prefab.gameObject.SetActive(false);

        }

    }

}
