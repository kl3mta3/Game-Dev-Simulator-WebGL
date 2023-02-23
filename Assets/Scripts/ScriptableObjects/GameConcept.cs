using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = " New GameConcept", menuName = "GameConcept")]
public class GameConcept : ScriptableObject
{
   [SerializeField]
    internal string gameConceptName;
    [SerializeField]
    internal int gameConceptId;
    
    [TextArea(5, 5)]
    [SerializeField]
    internal string gameDescription;

    [SerializeField]
    internal float modelingDificulty;
    [SerializeField]
    internal float codingDificulty;
    [SerializeField]
    internal float designDificulty;
    [SerializeField]
    internal float marketingDificulty;

    [SerializeField]
    internal float gamePriceSteem;
    [SerializeField]
    internal float gamePriceEpik;
    [SerializeField]
    internal float gamePricePear;
    [SerializeField]
    internal float gamePriceCyborg;
    [SerializeField]
    internal float gamePricePlayBox;
    [SerializeField]
    internal float gamePriceXStation;

    [SerializeField]
    internal float steemMaintenanceFee;
    [SerializeField]
    internal float epikMaintenanceFee;
    [SerializeField]
    internal float pearMaintenanceFee;
    [SerializeField]
    internal float cyborgMaintenanceFee;
    [SerializeField]
    internal float playBoxMaintenanceFee;
    [SerializeField]
    internal float xStationMaintenanceFee;

    [SerializeField]
    internal float devTime;


    //added for after built

    
    internal float popularity;

    internal float baseProfit;

    internal float viralChance;

   
    internal float cashMadeToDate;

    
    internal float costToDate;

    internal float steemUnitsSold;
    internal float epikUnitsSold;
    internal float pearlUnitsSold;
    internal float cyborgUnitsSold;
    internal float playBoxUnitsSold;
    internal float xStationUnitsSold;

    internal float totalUnitsSold;

    
    internal bool isReleased;

   
    internal bool onSteem;

    
    internal bool onEpik;

    
    internal bool onPear;

    
    internal bool onCyborg;

    
    internal bool onPlayBox;

   
    internal bool onXStation;




}
