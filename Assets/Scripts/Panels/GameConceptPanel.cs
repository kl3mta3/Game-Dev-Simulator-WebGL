using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameConceptPanel : MonoBehaviour
{
    [SerializeField]
    internal GameConcept gameConcept;

    [SerializeField]
    internal Player player;
    [SerializeField]
    internal BuildAGamePanel buildAGamePanel;

    [SerializeField]
    internal TextMeshProUGUI gameName;
   
    [SerializeField]
    internal TextMeshProUGUI gameDescription;
    [SerializeField]
    internal TextMeshProUGUI modelingDificultyText;
    [SerializeField]
    internal TextMeshProUGUI codingDificultyText;
    [SerializeField]
    internal TextMeshProUGUI designDificultyText;
    [SerializeField]
    internal TextMeshProUGUI marketingDificultyText;

    [SerializeField]
    internal GameObject devTimeShort;
    [SerializeField]
    internal GameObject devTimeAverage;
    [SerializeField]
    internal GameObject devTimeLong;
    [SerializeField]
    internal GameObject devTimeExtreme;
    

    internal int _short=200;
   
    internal int _average = 300;
    
    internal int _long = 400;
   
    internal int _extreme = 500;

    [SerializeField]
    internal GameConceptPanel currentGameConceptPanel;

    public void SetPanel(GameConcept _gameConcept)
    {
        gameName.text = _gameConcept.gameConceptName;
        gameDescription.text = _gameConcept.gameDescription;
        gameConcept = _gameConcept;
        modelingDificultyText.text = _gameConcept.modelingDificulty.ToString();
        codingDificultyText.text = _gameConcept.codingDificulty.ToString();
        designDificultyText.text = _gameConcept.designDificulty.ToString();
        marketingDificultyText.text = _gameConcept.marketingDificulty.ToString();

        if (_gameConcept.devTime <= _short)
        {
            devTimeShort.SetActive(true);
            devTimeAverage.SetActive(false);
            devTimeExtreme.SetActive(false);
            devTimeLong.SetActive(false);
        }
        else if (_gameConcept.devTime <= _average)
        {
            devTimeAverage.SetActive(true);
            devTimeShort.SetActive(false);
            devTimeExtreme.SetActive(false);
            devTimeLong.SetActive(false);
        }
        else if (_gameConcept.devTime <= _long)
        {
            devTimeLong.SetActive(true);
            devTimeShort.SetActive(false);
            devTimeAverage.SetActive(false);
            devTimeExtreme.SetActive(false);
        }
        else if (_gameConcept.devTime <= _extreme)
        {
            devTimeExtreme.SetActive(true);
            devTimeShort.SetActive(false);
            devTimeAverage.SetActive(false);
            devTimeLong.SetActive(false);
        }
    }
    public void ChooseGameConcept()
    {
        
        player.currentGame = gameConcept;
        buildAGamePanel.currentGameConcept = gameConcept;
        player.soundManager.PlayButton1Sound();
        //currentGameConceptPanel.SetPanel(gameConcept);
    }

    public void SetCurrentGamePanel()
    {


        currentGameConceptPanel.SetPanel(gameConcept);
        buildAGamePanel.currentGameConcept = gameConcept;
        player.soundManager.PlayButton1Sound();

    }



}

