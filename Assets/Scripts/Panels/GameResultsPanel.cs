using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using Unity.VisualScripting;

public class GameResultsPanel : MonoBehaviour
{
    [SerializeField]
    internal Player player;
    [SerializeField]
    internal GameController gameController;
    [SerializeField]
    internal PrepareForReleasePanel prepareForReleasePanel;
    [SerializeField]
    internal ViralTrendsSoObject viralTrendSo;

    [SerializeField]
    internal GameObject chooseAGamePanel;

    [SerializeField]
    internal TextMeshProUGUI clicksFromMiniGameText;
    [SerializeField]
    internal TextMeshProUGUI totalPossibleClicksText;
    [SerializeField]
    internal TextMeshProUGUI successRateText;

    internal float totalPossibleClicks;
    internal float clicksFromMiniGame;

    internal float miniGameSuccessRate;


    //marketing Results 
    [SerializeField]
    internal TextMeshProUGUI marketingBudgetText;
    [SerializeField]
    internal TextMeshProUGUI viralMarketingTrendText;
    [SerializeField]
    internal TextMeshProUGUI faceFlyerBudgetText;
    [SerializeField]
    internal TextMeshProUGUI tikTikBudgetText;
    [SerializeField]
    internal TextMeshProUGUI boogleBudgetText;
    [SerializeField]
    internal TextMeshProUGUI eweTubeBudgetText;
    [SerializeField]
    internal TextMeshProUGUI marketingSuccessRateText;

    [SerializeField]
    internal TextMeshProUGUI salesBoostEarnedText;
    [SerializeField]
    internal BarGraph marketingBarGraph;

    internal float faceFlyerBudgetDifference;
    internal float tikTikBudgetDifference;
    internal float boogleBudgetDifference;
    internal float eweTubeBudgetDifference;

    internal float marketingSalesBoostEarned;

    internal float marketingBudget;

    internal float faceFlyerMarketingOutcome;
    internal float tikTikMarketingOutcome;
    internal float boogleMarketingOutcome;
    internal float eweTubeMarketingOutcome;

    internal float faceFlyerMarketingOutcomePrediction;
    internal float tikTikMarketingOutcomePercentPrediction;
    internal float boogleMarketingOutcomePercentPrediction;
    internal float eweTubeMarketingOutcomePercentPrediction;

    internal float faceFlyerMarketingFinalTotal;
    internal float tikTikMarketingFinalTotal;
    internal float boogleMarketingFinalTotal;
    internal float eweTubeMarketingFinalTotal;

    internal float totalItemizedMarketBudgetboost;
    internal float faceFlyerMarketBudgetboost;
    internal float tikTikMarketBudgetboost;
    internal float boogleMarketBudgetboost;
    internal float eweTubeMarketBudgetboost;

    //platform Results
    [SerializeField]
    internal TextMeshProUGUI totalPlatformesReleasedOnText;
    [SerializeField]
    internal TextMeshProUGUI viralPlatformSectorText;
    [SerializeField]
    internal TextMeshProUGUI steemUnitsSoldText;
    [SerializeField]
    internal TextMeshProUGUI epikUnitsSoldText;
    [SerializeField]
    internal TextMeshProUGUI pearUnitsSoldText;
    [SerializeField]
    internal TextMeshProUGUI cyborgUnitsSoldText;
    [SerializeField]
    internal TextMeshProUGUI playBoxUnitsSoldText;
    [SerializeField]
    internal TextMeshProUGUI xStationUnitsSoldText;
    [SerializeField]
    internal TextMeshProUGUI bestPlatformText;
    [SerializeField]
    internal TextMeshProUGUI totalUnitsSoldText;

    internal Dictionary<string, bool> platformBoolDict = new Dictionary<string, bool>();

    internal float totalPlatformsReleasedOn;

    internal static float totalUnitsSold;
    internal static float steemUnitsSold;
    internal static float epikUnitsSold;
    internal static float pearUnitsSold;
    internal static float cyborgUnitsSold;
    internal static float playBoxUnitsSold;
    internal static float xStationUnitsSold;



    internal float[] platformUnitsSold = new float[6] { steemUnitsSold, epikUnitsSold, pearUnitsSold, cyborgUnitsSold, playBoxUnitsSold, xStationUnitsSold };
    internal string[] platformNames = new string[6] { "Steem", "Epik", "Pear", "Cyborg", "PlayBox", "XStation" };
    internal Dictionary<string, float> platformUnitsSoldDict = new Dictionary<string, float>();

    internal string bestPlatform = "";

    //demographic Results

    [SerializeField]
    internal TextMeshProUGUI ViralDemographicSectorText;
    internal string viralDemographicSector;
    [SerializeField]
    internal TextMeshProUGUI demographicSalesBoostEarnedText;

    internal static float kidsDemographicOutcome;
    internal static float teensDemographicOutcome;
    internal static float collegeDemographicOutcome;
    internal static float adultsDemographicOutcome;
    internal static float boomersDemographicOutcome;

    internal float kidsDemographicFinalTotal;
    internal float teensDemographicFinalTotal;
    internal float collegeDemographicFinalTotal;
    internal float adultsDemographicFinalTotal;
    internal float boomersDemographicFinalTotal;

    internal float demographicSalesBoostEarned;

    internal float[] demographicOutcomes = new float[5] { kidsDemographicOutcome, teensDemographicOutcome, collegeDemographicOutcome, adultsDemographicOutcome, boomersDemographicOutcome };
    internal string[] demographicNames = new string[5] { "Kids", "Teens", "College", "Adults", "Boomers" };
    internal Dictionary<string, float> demographicOutcomesDict = new Dictionary<string, float>();

    //internal string viralDemographicSector;
    [SerializeField]
    internal PieChart demographicPieChart;




    // Results Summary 

    [SerializeField]
    internal PieChart summaryDonutChart;
    [SerializeField]
    internal BuildAGamePanel buildAGamePanel;
    [SerializeField]
    internal GameObject miniGamePanel;



    internal float steemGrossProfit;
    internal float steemNetProfit;

    internal float epikGrossProfit;
    internal float epikNetProfit;

    internal float pearGrossProfit;
    internal float pearNetProfit;

    internal float cyborgGrossProfit;
    internal float cyborgNetProfit;

    internal float playBoxGrossProfit;
    internal float playBoxNetProfit;

    internal float xStationGrossProfit;
    internal float xStationNetProfit;


    internal float totalProfit;
    internal float maintenanceFee;
    internal float taxRate;

    internal float modelingClicks;
    internal float codingClicks;
    internal float designClicks;
    internal float marketingClicks;

    internal float mostFocusedFloat;
    [SerializeField]
    internal GameObject star1;
    [SerializeField]
    internal GameObject star2;
    [SerializeField]
    internal GameObject star3;
    [SerializeField]
    internal GameObject star4;
    [SerializeField]
    internal GameObject star5;

    internal string mostFocusedSkillModeling = "3D Modeling +1 to 3D Modeling Skill";
    internal string mostFocusedSkillCoding = "Coding  +1 to Coding Skill";
    internal string mostFocusedSkillDesign = "Design  +1 to Design Skill";
    internal string mostFocusedSkillMarketing = "Marketing  +1 to Marketing Skill";

    internal bool addModelingPoint=false;
    internal bool addCodingPoint = false;
    internal bool AddDesignPoint = false;
    internal bool addMarketingPoint = false;

    [SerializeField]
    internal TextMeshProUGUI totalProfitText;

    [SerializeField]
    internal TextMeshProUGUI mostFocusedSkillText;

    [SerializeField]
    internal TextMeshProUGUI steemGrossProfitText;
    [SerializeField]
    internal TextMeshProUGUI steemNetProfitText;
    [SerializeField]
    internal TextMeshProUGUI steemPlatformCutText;
    [SerializeField]
    internal TextMeshProUGUI steemTaxesText;
    [SerializeField]
    internal TextMeshProUGUI steemMaintenanceFeeText;


    [SerializeField]
    internal TextMeshProUGUI epikGrossProfitText;
    [SerializeField]
    internal TextMeshProUGUI epikNetProfitText;
    [SerializeField]
    internal TextMeshProUGUI epikPlatformCutText;
    [SerializeField]
    internal TextMeshProUGUI epikTaxesText;
    [SerializeField]
    internal TextMeshProUGUI epikMaintenanceFeeText;


    [SerializeField]
    internal TextMeshProUGUI pearGrossProfitText;
    [SerializeField]
    internal TextMeshProUGUI pearNetProfitText;
    [SerializeField]
    internal TextMeshProUGUI pearPlatformCutText;
    [SerializeField]
    internal TextMeshProUGUI pearTaxesText;
    [SerializeField]
    internal TextMeshProUGUI pearMaintenanceFeeText;

    [SerializeField]
    internal TextMeshProUGUI cyborgGrossProfitText;
    [SerializeField]
    internal TextMeshProUGUI cyborgNetProfitText;
    [SerializeField]
    internal TextMeshProUGUI cyborgPlatformCutText;
    [SerializeField]
    internal TextMeshProUGUI cyborgTaxesText;
    [SerializeField]
    internal TextMeshProUGUI cyborgMaintenanceFeeText;

    [SerializeField]
    internal TextMeshProUGUI playBoxGrossProfitText;
    [SerializeField]
    internal TextMeshProUGUI playBoxNetProfitText;
    [SerializeField]
    internal TextMeshProUGUI playBoxPlatformCutText;
    [SerializeField]
    internal TextMeshProUGUI playBoxTaxesText;
    [SerializeField]
    internal TextMeshProUGUI playBoxMaintenanceFeeText;

    [SerializeField]
    internal TextMeshProUGUI xStationGrossProfitText;
    [SerializeField]
    internal TextMeshProUGUI xStationNetProfitText;
    [SerializeField]
    internal TextMeshProUGUI xStationPlatformCutText;
    [SerializeField]
    internal TextMeshProUGUI xStationTaxesText;
    [SerializeField]
    internal TextMeshProUGUI xStationMaintenanceFeeText;


    internal bool isNoStar = false;
    internal bool isOneStar = false;
    internal bool isTwoStar = false;
    internal bool isThreeStar = false;
    internal bool isFourStar = false;
    internal bool isFiveStar = false;




    public void Start()
    {

        // set dictonaries
        for (int i = 0; i < platformUnitsSold.Length; i++)
        {
            platformUnitsSoldDict.Add(platformNames[i], platformUnitsSold[i]);
        }


        for (int i = 0; i < demographicOutcomes.Length; i++)
        {
            demographicOutcomesDict.Add(demographicNames[i], demographicOutcomes[i]);
        }




    }

    public void OnEnable()
    {
       // viralTrendSo.RandomizeViralTrends(); // remove after testing results page...... ran by came controller   
       // demographicSalesBoostEarned = Random.Range(0, 100);//remove after testing
      //  marketingSalesBoostEarned = Random.Range(0, 100);//remove after testing
      //  miniGameSuccessRate = Random.Range(60, 100);//remove after testing

        clicksFromMiniGame = prepareForReleasePanel.faceFlyerMiniGameBonus + prepareForReleasePanel.tikTikMiniGameBonus + prepareForReleasePanel.boogleMiniGameBonus + prepareForReleasePanel.eweTubeMiniGameBonus;
        totalPossibleClicks = prepareForReleasePanel.totalMiniGameBonusChances;
        miniGameSuccessRate = (clicksFromMiniGame / totalPossibleClicks) * 100;
        DecideDemographicOutcome();
        DecideMarketingOutcome();
        DecidePlatformOutcome();
        DecideSummaryOutcome();
        DisplayPlatformResults();
        DisplyDemographicData();
        DisplayMarketingData();
        DisplaySummary();
    }

    public void OnDisable()
    {
        totalPossibleClicks = 0;
        clicksFromMiniGame = 0;
        miniGameSuccessRate = 0;
        ResetDemographicData();
        ResetMarketingData();
        ResetPlatformData();
        ResetSummary();
    }

    //Demographic Results 

    public float FindDeographicFloatFromName(string floatName)
    {
        float floatToReturn = 0;
        foreach (KeyValuePair<string, float> entry in demographicOutcomesDict)
        {
            if (entry.Key == floatName)
            {
                floatToReturn = entry.Value;
            }
        }
        return floatToReturn;
    }
    public string DecideDemographicViralSector()
    {
        string viralDemographicSector = "";
        float viralDemographicSectorfloat = Random.Range(0, 4);

        switch (viralDemographicSectorfloat)
        {
            case 0:
                viralDemographicSector = "Kids";

                break;
            case 1:
                viralDemographicSector = "Teens";
                break;
            case 2:
                viralDemographicSector = "College";
                break;
            case 3:
                viralDemographicSector = "Adults";
                break;
            case 4:
                viralDemographicSector = "Boomers";
                break;
        }

        return viralDemographicSector;
    }
    public void DisplyDemographicData()
    {

        ViralDemographicSectorText.text = viralTrendSo.currentViralDemographicTrendName;
        demographicPieChart.SetValues(demographicPieChart.values);
        demographicSalesBoostEarnedText.text = demographicSalesBoostEarned.ToString();
    }
    public void DecideDemographicOutcome()
    {
        viralDemographicSector = viralTrendSo.currentViralDemographicTrendName;
        float currentTotalDemographic = 100;
        float runningTotal = 0;
        switch (viralDemographicSector)
        {
            case "Kids":
                runningTotal = 0;
                boomersDemographicOutcome = currentTotalDemographic * Random.Range(0.1f, 0.3f);
                runningTotal += boomersDemographicOutcome;
                adultsDemographicOutcome = (currentTotalDemographic - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += adultsDemographicOutcome;
                collegeDemographicOutcome = (currentTotalDemographic - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += collegeDemographicOutcome;
                teensDemographicOutcome = (currentTotalDemographic - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += teensDemographicOutcome;
                kidsDemographicOutcome = currentTotalDemographic - runningTotal;
                demographicPieChart.values[0] = kidsDemographicOutcome;
                demographicPieChart.values[1] = teensDemographicOutcome;
                demographicPieChart.values[2] = collegeDemographicOutcome;
                demographicPieChart.values[3] = adultsDemographicOutcome;
                demographicPieChart.values[4] = boomersDemographicOutcome;


                break;

            case "Teens":
                runningTotal = 0;
                kidsDemographicOutcome = currentTotalDemographic * Random.Range(0.1f, 0.3f);
                runningTotal += kidsDemographicOutcome;
                boomersDemographicOutcome = (currentTotalDemographic - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += boomersDemographicOutcome;
                adultsDemographicOutcome = (currentTotalDemographic - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += adultsDemographicOutcome;
                collegeDemographicOutcome = (currentTotalDemographic - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += collegeDemographicOutcome;
                teensDemographicOutcome = currentTotalDemographic - runningTotal;
                demographicPieChart.values[0] = kidsDemographicOutcome;
                demographicPieChart.values[1] = teensDemographicOutcome;
                demographicPieChart.values[2] = collegeDemographicOutcome;
                demographicPieChart.values[3] = adultsDemographicOutcome;
                demographicPieChart.values[4] = boomersDemographicOutcome;
                //pieChart.SetValues(pieChart.values);
                break;


            case "College":
                runningTotal = 0;
                teensDemographicOutcome = currentTotalDemographic * Random.Range(0.1f, 0.3f);
                runningTotal += teensDemographicOutcome;
                kidsDemographicOutcome = (currentTotalDemographic - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += kidsDemographicOutcome;
                boomersDemographicOutcome = (currentTotalDemographic - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += boomersDemographicOutcome;
                adultsDemographicOutcome = (currentTotalDemographic - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += adultsDemographicOutcome;
                collegeDemographicOutcome = currentTotalDemographic - runningTotal;
                demographicPieChart.values[0] = kidsDemographicOutcome;
                demographicPieChart.values[1] = teensDemographicOutcome;
                demographicPieChart.values[2] = collegeDemographicOutcome;
                demographicPieChart.values[3] = adultsDemographicOutcome;
                demographicPieChart.values[4] = boomersDemographicOutcome;
                //pieChart.SetValues(pieChart.values);
                break;


            case "Adults":
                runningTotal = 0;
                collegeDemographicOutcome = currentTotalDemographic * Random.Range(0.1f, 0.3f);
                runningTotal += collegeDemographicOutcome;
                teensDemographicOutcome = (currentTotalDemographic - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += teensDemographicOutcome;
                kidsDemographicOutcome = (currentTotalDemographic - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += kidsDemographicOutcome;
                boomersDemographicOutcome = (currentTotalDemographic - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += boomersDemographicOutcome;
                adultsDemographicOutcome = currentTotalDemographic - runningTotal;
                demographicPieChart.values[0] = kidsDemographicOutcome;
                demographicPieChart.values[1] = teensDemographicOutcome;
                demographicPieChart.values[2] = collegeDemographicOutcome;
                demographicPieChart.values[3] = adultsDemographicOutcome;
                demographicPieChart.values[4] = boomersDemographicOutcome;
                //pieChart.SetValues(pieChart.values);
                break;


            case "Boomers":
                runningTotal = 0;
                adultsDemographicOutcome = currentTotalDemographic * Random.Range(0.1f, 0.3f);
                runningTotal += adultsDemographicOutcome;
                collegeDemographicOutcome = (currentTotalDemographic - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += collegeDemographicOutcome;
                teensDemographicOutcome = (currentTotalDemographic - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += teensDemographicOutcome;
                kidsDemographicOutcome = (currentTotalDemographic - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += kidsDemographicOutcome;
                boomersDemographicOutcome = currentTotalDemographic - runningTotal;
                demographicPieChart.values[0] = kidsDemographicOutcome;
                demographicPieChart.values[1] = teensDemographicOutcome;
                demographicPieChart.values[2] = collegeDemographicOutcome;
                demographicPieChart.values[3] = adultsDemographicOutcome;
                demographicPieChart.values[4] = boomersDemographicOutcome;
                //pieChart.SetValues(pieChart.values);
                break;

        }

        kidsDemographicFinalTotal = kidsDemographicOutcome - prepareForReleasePanel.playerKidsPrediction;
        // Debug.Log("kidsDemographicFinalTotal =" + kidsDemographicFinalTotal);
        teensDemographicFinalTotal = teensDemographicOutcome - prepareForReleasePanel.playerTeensPrediction;
        //Debug.Log("teensDemographicFinalTotall =" + teensDemographicFinalTotal);
        collegeDemographicFinalTotal = collegeDemographicOutcome - prepareForReleasePanel.playerCollegePrediction;
        //Debug.Log(" collegeDemographicFinalTotal =" + collegeDemographicFinalTotal);
        adultsDemographicFinalTotal = adultsDemographicOutcome - prepareForReleasePanel.playerAdultsPrediction;
        //Debug.Log("adultsDemographicFinalTotal =" + adultsDemographicFinalTotal);
        boomersDemographicFinalTotal = boomersDemographicOutcome - prepareForReleasePanel.playerBoomersPrediction;
        // Debug.Log(" boomersDemographicFinalTotal =" + boomersDemographicFinalTotal);

        demographicSalesBoostEarned = (kidsDemographicFinalTotal + teensDemographicFinalTotal + collegeDemographicFinalTotal + adultsDemographicFinalTotal + boomersDemographicFinalTotal);
        //Debug.Log("demographicTotalDifference Pre Adjust =" + demographicTotalDifference);
        if (player.playerLevel <= 1)
        {
            if (demographicSalesBoostEarned >= 1)
            {
                demographicSalesBoostEarned = Mathf.Round(((demographicSalesBoostEarned + clicksFromMiniGame) * (miniGameSuccessRate / 100) + totalItemizedMarketBudgetboost));
            }
            else
            {
                demographicSalesBoostEarned = 0;

            }
        }
        else if (player.playerLevel > 1)
        {
            if (demographicSalesBoostEarned >= 1)
            {
                demographicSalesBoostEarned = Mathf.Round((demographicSalesBoostEarned + clicksFromMiniGame) * (miniGameSuccessRate / 100) * (player.playerLevel / 2) + totalItemizedMarketBudgetboost);
            }
            else
            {
                demographicSalesBoostEarned = 0;

            }
        }


    }
    public void ResetDemographicData()
    {

        kidsDemographicOutcome = 0;
        teensDemographicOutcome = 0;
        collegeDemographicOutcome = 0;
        adultsDemographicOutcome = 0;
        boomersDemographicOutcome = 0;


        kidsDemographicFinalTotal = 0;
        teensDemographicFinalTotal = 0;
        collegeDemographicFinalTotal = 0;
        adultsDemographicFinalTotal = 0;
        boomersDemographicFinalTotal = 0;

        demographicSalesBoostEarned = 0;

        for (int i = 0; i < demographicPieChart.values.Length; i++)
        {
            demographicPieChart.values[i] = 0;
        }
        demographicSalesBoostEarnedText.text = "";

    }


    //platform Results
    public void DecidePlatformOutcome()
    {

        totalPlatformsReleasedOn = prepareForReleasePanel.TotalPlatfomrsReleasedOn();
        List<float> allUnitsIndividulized = new List<float>();
        float unitBoostMultiplier = ((marketingBudget / 1000)*1.5f);
        if (totalPlatformsReleasedOn > 0)
        {
            bestPlatform = CalculateBestPlatform();

            if (prepareForReleasePanel.isOnSteem)
            {
                steemUnitsSold = Mathf.Round(((gameController.steembaseUnits * (marketingSalesBoostEarned + demographicSalesBoostEarned) * (miniGameSuccessRate / 100))) * unitBoostMultiplier);
                allUnitsIndividulized.Add(steemUnitsSold);
            }
            else
            {
                steemUnitsSold = 0;
                allUnitsIndividulized.Add(steemUnitsSold);
            }

            if (prepareForReleasePanel.isOnEpik)
            {
                epikUnitsSold = Mathf.Round(((gameController.epikbaseUnits * (marketingSalesBoostEarned + demographicSalesBoostEarned) * (miniGameSuccessRate / 100))) * unitBoostMultiplier);
                allUnitsIndividulized.Add(epikUnitsSold);
            }
            else
            {
                epikUnitsSold = 0;
                allUnitsIndividulized.Add(epikUnitsSold);
            }
            if (prepareForReleasePanel.isOnPear)
            {
                pearUnitsSold = Mathf.Round(((gameController.pearbaseUnits * (marketingSalesBoostEarned + demographicSalesBoostEarned) * (miniGameSuccessRate / 100))) * unitBoostMultiplier);
            }
            else
            {
                pearUnitsSold = 0;
                allUnitsIndividulized.Add(pearUnitsSold);
            }

            if (prepareForReleasePanel.isOnCyborg)
            {
                cyborgUnitsSold = Mathf.Round(((gameController.cyborgbaseUnits * (marketingSalesBoostEarned + demographicSalesBoostEarned) * (miniGameSuccessRate / 100))) * unitBoostMultiplier);
                allUnitsIndividulized.Add(cyborgUnitsSold);
            }
            else
            {
                cyborgUnitsSold = 0;
                allUnitsIndividulized.Add(cyborgUnitsSold);
            }

            if (prepareForReleasePanel.isOnPlayBox)
            {
                playBoxUnitsSold = Mathf.Round(((gameController.playBoxbaseUnits * (marketingSalesBoostEarned + demographicSalesBoostEarned) * (miniGameSuccessRate / 100))) * unitBoostMultiplier);
            }
            else
            {
                playBoxUnitsSold = 0;
                allUnitsIndividulized.Add(playBoxUnitsSold);

            }

            if (prepareForReleasePanel.isOnXStation)
            {
                xStationUnitsSold = Mathf.Round(((gameController.xStationbaseUnits * (marketingSalesBoostEarned + demographicSalesBoostEarned) * (miniGameSuccessRate / 100))) * unitBoostMultiplier);

            }
            else
            {
                xStationUnitsSold = 0;
                allUnitsIndividulized.Add(xStationUnitsSold);

            }

            totalUnitsSold = FindTotalUnitsSold();
        }
        else
        {
            bestPlatform = "";
            steemUnitsSold = 0;
            epikUnitsSold = 0;
            cyborgUnitsSold = 0;
            playBoxUnitsSold = 0;
            xStationUnitsSold = 0;
            totalUnitsSold = FindTotalUnitsSold();

        }
        totalUnitsSold = (steemUnitsSold + epikUnitsSold + pearUnitsSold + cyborgUnitsSold + playBoxUnitsSold + xStationUnitsSold);

        float bestPlatformFloat = Mathf.Max(allUnitsIndividulized.ToArray());


        if (bestPlatformFloat == steemUnitsSold)
        {

            bestPlatform = "Steem";

        }
        else if (bestPlatformFloat == epikUnitsSold)
        {
            bestPlatform = "Epik";

        }
        else if (bestPlatformFloat == pearUnitsSold)
        {
            bestPlatform = "Pear";

        }
        else if (bestPlatformFloat == cyborgUnitsSold)
        {
            bestPlatform = "Cyborg";

        }
        else if (bestPlatformFloat == playBoxUnitsSold)
        {

            bestPlatform = "PlayBox";
        }
        else if (bestPlatformFloat == xStationUnitsSold)
        {

            bestPlatform = "Xstation";
        }
        else
        {
            bestPlatform = "";

        }





    }
    public void ResetPlatformData()
    {

        for (int i = 0; i < platformUnitsSold.Length; i++)

        {
            platformUnitsSold[i] = 0;
        }
        totalUnitsSold = 0;

        totalPlatformsReleasedOn = 0;
    }

    public float FindTotalUnitsSold()
    {
        float totalUnitsSold = 0;

        for (int i = 0; i < platformUnitsSold.Length; i++)
        {
            totalUnitsSold += platformUnitsSold[i];
        }

        return totalUnitsSold;

    }

    public void DisplayPlatformResults()
    {




        steemUnitsSoldText.text = steemUnitsSold.ToString();
        epikUnitsSoldText.text = epikUnitsSold.ToString();
        pearUnitsSoldText.text = pearUnitsSold.ToString();
        cyborgUnitsSoldText.text = cyborgUnitsSold.ToString();
        playBoxUnitsSoldText.text = playBoxUnitsSold.ToString();
        xStationUnitsSoldText.text = xStationUnitsSold.ToString();
        totalPlatformesReleasedOnText.text = prepareForReleasePanel.TotalPlatfomrsReleasedOn().ToString();
        viralPlatformSectorText.text = viralTrendSo.currentViralPlatformTrendName.ToString();

        bestPlatformText.text = bestPlatform.ToString();
        totalUnitsSoldText.text = totalUnitsSold.ToString();

    }

    public string CalculateBestPlatform()
    {
        string bestplat = "";
        float bestplatinUnits = Mathf.Max(platformUnitsSold);


        return bestplat;
    }

    //Marketing Results

    public void DisplayMarketingData()
    {
        viralMarketingTrendText.text = viralTrendSo.currentViralMarketingTrendName;

        float totalforBarGraph = faceFlyerMarketingFinalTotal + tikTikMarketingFinalTotal + boogleMarketingFinalTotal + eweTubeMarketingFinalTotal;
        faceFlyerBudgetText.text = faceFlyerMarketingFinalTotal.ToString("F0")+"%";
        marketingBarGraph.values[0] = faceFlyerMarketingFinalTotal;
        tikTikBudgetText.text = tikTikMarketingFinalTotal.ToString("F0")+"%";
        marketingBarGraph.values[1] = tikTikMarketingFinalTotal;
        boogleBudgetText.text = boogleMarketingFinalTotal.ToString("F0")+"%";
        marketingBarGraph.values[2] = boogleMarketingFinalTotal;
        eweTubeBudgetText.text = eweTubeMarketingFinalTotal.ToString("F0")+"%";
        marketingBarGraph.values[3] = eweTubeMarketingFinalTotal;

        marketingSuccessRateText.text = Mathf.Round(miniGameSuccessRate).ToString();
        marketingBarGraph.SetValues(marketingBarGraph.values);

        salesBoostEarnedText.text = Mathf.Round(marketingSalesBoostEarned).ToString();
    }
    public void DecideMarketingOutcome()
    {
        string viralDemographicSector = viralTrendSo.currentViralMarketingTrendName;
        ViralDemographicSectorText.text = viralDemographicSector;
        float currentTotalMarketing = 100;
        float runningTotal = 0;
        marketingBudget = prepareForReleasePanel.marketingBudget;


        switch (viralDemographicSector)
        {
            case "FaceFlyer":
                runningTotal = 0;

                eweTubeMarketingOutcome = currentTotalMarketing * Random.Range(0.1f, 0.3f);
                runningTotal += eweTubeMarketingOutcome;

                boogleMarketingOutcome = (currentTotalMarketing - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += boogleMarketingOutcome;

                tikTikMarketingOutcome = (currentTotalMarketing - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += tikTikMarketingOutcome;

                faceFlyerMarketingOutcome = currentTotalMarketing - runningTotal;


                break;

            case "TikTik":
                runningTotal = 0;

                faceFlyerMarketingOutcome = currentTotalMarketing * Random.Range(0.1f, 0.3f);
                runningTotal += faceFlyerMarketingOutcome;

                eweTubeMarketingOutcome = (currentTotalMarketing - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += eweTubeMarketingOutcome;

                boogleMarketingOutcome = (currentTotalMarketing - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += boogleMarketingOutcome;

                tikTikMarketingOutcome = currentTotalMarketing - runningTotal;
                break;


            case "Boogle":
                runningTotal = 0;

                tikTikMarketingOutcome = currentTotalMarketing * Random.Range(0.1f, 0.3f);
                runningTotal += tikTikMarketingOutcome;

                faceFlyerMarketingOutcome = (currentTotalMarketing - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += faceFlyerMarketingOutcome;

                eweTubeMarketingOutcome = (currentTotalMarketing - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += eweTubeMarketingOutcome;

                boogleMarketingOutcome = currentTotalMarketing - runningTotal;

                break;


            case "EweTube":
                runningTotal = 0;

                boogleMarketingOutcome = currentTotalMarketing * Random.Range(0.1f, 0.3f);
                runningTotal += boogleMarketingOutcome;

                tikTikMarketingOutcome = (currentTotalMarketing - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += tikTikMarketingOutcome;

                faceFlyerMarketingOutcome = (currentTotalMarketing - runningTotal) * Random.Range(0.1f, 0.3f);
                runningTotal += faceFlyerMarketingOutcome;

                eweTubeMarketingOutcome = currentTotalMarketing - runningTotal;

                break;

        }

        faceFlyerMarketingFinalTotal = (faceFlyerMarketingOutcome) - (faceFlyerMarketingOutcomePrediction);
        tikTikMarketingFinalTotal = (tikTikMarketingOutcome) - (tikTikMarketingOutcomePercentPrediction);
        boogleMarketingFinalTotal = (boogleMarketingOutcome) - (boogleMarketingOutcomePercentPrediction);
        eweTubeMarketingFinalTotal = (eweTubeMarketingOutcome) - (eweTubeMarketingOutcomePercentPrediction);

        faceFlyerMarketingOutcomePrediction = (prepareForReleasePanel.playerFaceFlyerBudget / marketingBudget) * 100;
        tikTikMarketingOutcomePercentPrediction = (prepareForReleasePanel.playerTikTikBudget / marketingBudget) * 100;
        boogleMarketingOutcomePercentPrediction = (prepareForReleasePanel.playerBoogleBudget / marketingBudget) * 100;
        eweTubeMarketingOutcomePercentPrediction = (prepareForReleasePanel.playerEweTubeBudget / marketingBudget) * 100;

        faceFlyerBudgetDifference = (prepareForReleasePanel.playerFaceFlyerBudget - (marketingBudget * (faceFlyerMarketingOutcome / 100)));
        tikTikBudgetDifference = (prepareForReleasePanel.playerTikTikBudget - (marketingBudget * (tikTikMarketingOutcome / 100)));
        boogleBudgetDifference = (prepareForReleasePanel.playerBoogleBudget - (marketingBudget * (boogleMarketingOutcome / 100)));
        eweTubeBudgetDifference = (prepareForReleasePanel.playerEweTubeBudget - (marketingBudget * (eweTubeMarketingOutcome / 100)));
        marketingSalesBoostEarned = (faceFlyerBudgetDifference + tikTikBudgetDifference + boogleBudgetDifference + eweTubeBudgetDifference);

        faceFlyerMarketBudgetboost = Mathf.Round((prepareForReleasePanel.playerFaceFlyerBudget / 1000) * (miniGameSuccessRate / 100));
        tikTikMarketBudgetboost = Mathf.Round((prepareForReleasePanel.playerTikTikBudget / 1000) * (miniGameSuccessRate / 100));
        boogleMarketBudgetboost = Mathf.Round((prepareForReleasePanel.playerBoogleBudget / 1000) * (miniGameSuccessRate / 100));
        eweTubeMarketBudgetboost = Mathf.Round((prepareForReleasePanel.playerEweTubeBudget / 1000) * (miniGameSuccessRate / 100));
        totalItemizedMarketBudgetboost = (faceFlyerMarketBudgetboost + tikTikMarketBudgetboost + boogleMarketBudgetboost + eweTubeMarketBudgetboost);


        if (player.playerLevel <= 1)
        {

            //if(marketingTotalDifference>=1)
            //{
            marketingSalesBoostEarned = Mathf.Round(((marketingSalesBoostEarned + clicksFromMiniGame) * (miniGameSuccessRate / 100) + totalItemizedMarketBudgetboost));

            //}
            //else
            //{
            //    marketingTotalDifference = 0;

            //}
        }
        else if (player.playerLevel > 1)
        {
            //if (marketingTotalDifference >= 1)
            //{
            marketingSalesBoostEarned = Mathf.Round((marketingSalesBoostEarned + clicksFromMiniGame) * (miniGameSuccessRate / 100) * (player.playerLevel / 2) + totalItemizedMarketBudgetboost);
            //}
            //else
            //{
            //    marketingTotalDifference = 0;

            //}
        }
        Debug.Log("Total Difference: " + marketingSalesBoostEarned);
    }
    public void ResetMarketingData()
    {
        faceFlyerMarketingOutcome = 0;
        tikTikMarketingOutcome = 0;
        boogleMarketingOutcome = 0;
        eweTubeMarketingOutcome = 0;

        faceFlyerMarketingFinalTotal = 0;
        tikTikMarketingFinalTotal = 0;
        boogleMarketingFinalTotal = 0;
        eweTubeMarketingFinalTotal = 0;

        faceFlyerMarketingOutcomePrediction = 0;
        tikTikMarketingOutcomePercentPrediction = 0;
        boogleMarketingOutcomePercentPrediction = 0;
        eweTubeMarketingOutcomePercentPrediction = 0;


        faceFlyerBudgetDifference = 0;
        tikTikBudgetDifference = 0;
        boogleBudgetDifference = 0;
        eweTubeBudgetDifference = 0;

        totalItemizedMarketBudgetboost = 0;
        faceFlyerMarketBudgetboost = 0;
        tikTikMarketBudgetboost = 0;
        boogleMarketBudgetboost = 0;
        eweTubeMarketBudgetboost = 0;

        marketingSalesBoostEarned = 0;
        marketingBudget = 0;

        for (int i = 0; i < marketingBarGraph.values.Length; i++)
        {
            marketingBarGraph.values[i] = 0;
        }
    }

    // Results Summary 

    public void ResetSummary()
    {
        steemGrossProfit = 0;
        steemNetProfit = 0;

        epikGrossProfit = 0;
        epikNetProfit = 0;

        pearGrossProfit = 0;
        pearNetProfit = 0;

        cyborgGrossProfit = 0;
        cyborgNetProfit = 0;

        playBoxGrossProfit = 0;
        playBoxNetProfit = 0;

        xStationGrossProfit = 0;
        xStationNetProfit = 0;

        maintenanceFee = 0;
        taxRate = 0;
        totalProfit = 0;

        totalProfitText.text = "";

        mostFocusedSkillText.text = "";

        steemGrossProfitText.text = "";
        steemNetProfitText.text = "";
        steemPlatformCutText.text = "";
        steemTaxesText.text = "";
        steemMaintenanceFeeText.text = "";

        epikGrossProfitText.text = "";
        epikNetProfitText.text = "";
        epikPlatformCutText.text = "";
        epikTaxesText.text = "";
        epikMaintenanceFeeText.text = "";

        pearGrossProfitText.text = "";
        pearNetProfitText.text = "";
        pearPlatformCutText.text = "";
        pearTaxesText.text = "";
        pearMaintenanceFeeText.text = "";

        cyborgGrossProfitText.text = "";
        cyborgNetProfitText.text = "";
        cyborgPlatformCutText.text = "";
        cyborgTaxesText.text = "";
        cyborgMaintenanceFeeText.text = "";

        playBoxGrossProfitText.text = "";
        playBoxNetProfitText.text = "";
        playBoxPlatformCutText.text = "";
        playBoxTaxesText.text = "";
        playBoxMaintenanceFeeText.text = "";

        xStationGrossProfitText.text = "";
        xStationNetProfitText.text = "";
        xStationPlatformCutText.text = "";
        xStationTaxesText.text = "";
        xStationMaintenanceFeeText.text = "";

        modelingClicks = 0;
        codingClicks = 0;
        designClicks = 0;
        marketingClicks = 0;

        for (int i = 0; i < summaryDonutChart.values.Length; i++)
        {
            summaryDonutChart.values[i] = 0;
        }

        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        star4.SetActive(false);
        star5.SetActive(false);

        addModelingPoint = false;
        addCodingPoint = false;
        AddDesignPoint = false;
        addMarketingPoint = false;

}
    public void DecideSummaryOutcome()
    {
        modelingClicks = buildAGamePanel.modelingClicks;
        codingClicks = buildAGamePanel.codingClicks;
        designClicks = buildAGamePanel.designClicks;
        marketingClicks = buildAGamePanel.marketingClicks;
        GameConcept currentGameConcept = player.currentGame;
        taxRate = player.playerTaxRate;

        //mostFocusedFloat = Mathf.Max(buildAGamePanel.gameCreationClicksArray);

        steemGrossProfit = steemUnitsSold * currentGameConcept.gamePriceSteem;
        epikGrossProfit = epikUnitsSold * currentGameConcept.gamePriceEpik;
        pearGrossProfit = pearUnitsSold * currentGameConcept.gamePricePear;
        cyborgGrossProfit = cyborgUnitsSold * currentGameConcept.gamePriceCyborg;
        playBoxGrossProfit = playBoxUnitsSold * currentGameConcept.gamePricePlayBox;
        xStationGrossProfit = xStationUnitsSold * currentGameConcept.gamePriceXStation;



        steemNetProfit = GetNetProfit(steemGrossProfit, gameController.steemPlatformCut, taxRate, player.currentGame.steemMaintenanceFee);
        epikNetProfit = GetNetProfit(epikGrossProfit, gameController.epikPlatformCut, taxRate, player.currentGame.epikMaintenanceFee);
        pearNetProfit = GetNetProfit(pearGrossProfit, gameController.pearPlatformCut, taxRate, player.currentGame.pearMaintenanceFee);
        cyborgNetProfit = GetNetProfit(cyborgGrossProfit, gameController.cyborgPlatformCut, taxRate, player.currentGame.cyborgMaintenanceFee);
        playBoxNetProfit = GetNetProfit(playBoxGrossProfit, gameController.playBoxPlatformCut, taxRate, player.currentGame.playBoxMaintenanceFee);
        xStationNetProfit = GetNetProfit(xStationGrossProfit, gameController.xStationPlatformCut, taxRate, player.currentGame.xStationMaintenanceFee);

        summaryDonutChart.values[0] = steemNetProfit;
        summaryDonutChart.values[1] = epikNetProfit;
        summaryDonutChart.values[2] = pearNetProfit;
        summaryDonutChart.values[3] = cyborgNetProfit;
        summaryDonutChart.values[4] = playBoxNetProfit;
        summaryDonutChart.values[5] = xStationNetProfit;

        totalProfit = (steemNetProfit + epikNetProfit + pearNetProfit + cyborgNetProfit + playBoxNetProfit + xStationNetProfit);

        SetStars();
        isNoStar = false;
     isOneStar = false;
    isTwoStar = false;
     isThreeStar = false;
     isFourStar = false;
     isFiveStar = false;
}
    public string FindMostFocusedSkill()
    {
        string stringToReturn = "";
        float[] focusedFloats = new float[4];
        focusedFloats[0] = buildAGamePanel.modelingClicks;
        focusedFloats[1] = buildAGamePanel.codingClicks;
        focusedFloats[2] = buildAGamePanel.designClicks;
        focusedFloats[3] = buildAGamePanel.marketingClicks;
        
       float  _mostFocusedFloat = Mathf.Max(focusedFloats);

        if (_mostFocusedFloat == modelingClicks)
        {

            stringToReturn = mostFocusedSkillModeling;
            addModelingPoint = true;
            addCodingPoint = false;
            AddDesignPoint = false;
            addMarketingPoint = false;

        }
        else if (_mostFocusedFloat == codingClicks)
        {
            stringToReturn = mostFocusedSkillCoding;
            addModelingPoint = false;
            addCodingPoint = true;
            AddDesignPoint = false;
            addMarketingPoint = false;


        }
        else if (_mostFocusedFloat == designClicks)
        {

            stringToReturn = mostFocusedSkillDesign;
            addModelingPoint = false;
            addCodingPoint = false;
            AddDesignPoint = true;
            addMarketingPoint = false;

        }
        else if (_mostFocusedFloat == marketingClicks)
        {
            stringToReturn = mostFocusedSkillMarketing;
            addModelingPoint = false;
            addCodingPoint = false;
            AddDesignPoint = false;
            addMarketingPoint = true;


        }
        else
        {

            stringToReturn = "No Focused Skill Found";
            addModelingPoint = false;
            addCodingPoint = false;
            AddDesignPoint = false;
            addMarketingPoint = false;
        }

        return stringToReturn;
    }
    public void SetStars()
    {
        float totalpopularityPercent = 0;
        float popularityPercent = 0;
        //demographicSalesBoostEarned = Random.Range(0, 100);//remove after testing
        //marketingSalesBoostEarned = Random.Range(0, 100);//remove after testing
       // miniGameSuccessRate = Random.Range(60, 100);//remove after testing

        float popularityMultiplier = ((demographicSalesBoostEarned + marketingSalesBoostEarned) * (miniGameSuccessRate / 100));
        Debug.Log("popularityMultiplier: " + popularityMultiplier);
        float[] allDemographics = new float[5];
        
        allDemographics[0] = kidsDemographicFinalTotal;
       // Debug.Log("kidsDemographicFinalTotal: " + kidsDemographicFinalTotal);
        allDemographics[1] = teensDemographicFinalTotal;
       // Debug.Log("teensDemographicFinalTotal: " + teensDemographicFinalTotal);
        allDemographics[2] = collegeDemographicFinalTotal;
       // Debug.Log("collegeDemographicFinalTotal: " + collegeDemographicFinalTotal);
        allDemographics[3] = adultsDemographicFinalTotal;
       // Debug.Log("adultsDemographicFinalTotal: " + adultsDemographicFinalTotal);
        allDemographics[4] = boomersDemographicFinalTotal;
        //Debug.Log("boomersDemographicFinalTotal: " + boomersDemographicFinalTotal);
        
        float firstPopularDemographic = Mathf.Max(allDemographics);
        for (int i = 0; i < allDemographics.Length; i++)
        {
            if (firstPopularDemographic == allDemographics[i])
            {

                allDemographics[i] = 0;
                break;
            }
        }
        float secondPopularDemographic = Mathf.Max(allDemographics);
        for (int i = 0; i < allDemographics.Length; i++)
        {
            if (secondPopularDemographic == allDemographics[i])
            {

                allDemographics[i] = 0;
                break;
            }
        }
        float thirdPopularDemographic = Mathf.Max(allDemographics);
        for (int i = 0; i < allDemographics.Length; i++)
        {
            if (thirdPopularDemographic == allDemographics[i])
            {

                allDemographics[i] = 0;
                break;
            }
        }

        firstPopularDemographic = (firstPopularDemographic * 3) * popularityMultiplier;
        //Debug.Log("firstPopularDemographic: " + firstPopularDemographic);
        secondPopularDemographic = (firstPopularDemographic * 2) * popularityMultiplier;
        //Debug.Log("secondPopularDemographic: " + secondPopularDemographic);
        thirdPopularDemographic = (firstPopularDemographic) * popularityMultiplier;
       // Debug.Log("thirdPopularDemographic: " + thirdPopularDemographic);

        popularityPercent = (firstPopularDemographic + secondPopularDemographic + thirdPopularDemographic);
        //Debug.Log("popularityPercent: " + popularityPercent);

        totalpopularityPercent =((popularityPercent / 6) / popularityMultiplier)/100;
//Debug.Log("totalpopularityPercent: " + totalpopularityPercent);
        
        if (totalpopularityPercent < 20)
        {

            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
            star4.SetActive(false);
            star5.SetActive(false);
            isNoStar = true;
            isOneStar = false;
            isTwoStar = false;
            isThreeStar = false;
            isFourStar = false;
            isFiveStar = false;
            

        }
        else if (totalpopularityPercent >= 20 && totalpopularityPercent < 40)
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
            star4.SetActive(false);
            star5.SetActive(false);
            isNoStar = false;
            isOneStar = true;
            isTwoStar = false;
            isThreeStar = false;
            isFourStar = false;
            isFiveStar = false;


        }
        else if (totalpopularityPercent >= 40 && totalpopularityPercent < 60)
        {

            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
            star4.SetActive(false);
            star5.SetActive(false);
            isNoStar = false;
            isOneStar = false;
            isTwoStar = true;
            isThreeStar = false;
            isFourStar = false;
            isFiveStar = false;

        }
        else if (totalpopularityPercent >= 60 && totalpopularityPercent < 80)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            star4.SetActive(false);
            star5.SetActive(false);
            isNoStar = false;
            isOneStar = false;
            isTwoStar = false;
            isThreeStar = true;
            isFourStar = false;
            isFiveStar = false;


        }
        else if (totalpopularityPercent > 80)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            star4.SetActive(true);
            star5.SetActive(false);
            isNoStar = false;
            isOneStar = false;
            isTwoStar = false;
            isThreeStar = false;
            isFourStar = true;
            isFiveStar = false;


        }
        else if (totalpopularityPercent > 95)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            star4.SetActive(true);
            star5.SetActive(true);
            isNoStar = false;
            isOneStar = false;
            isTwoStar = false;
            isThreeStar = false;
            isFourStar = false;
            isFiveStar = true;


        }


    }
    public float GetNetProfit(float grossProfit, float platformCut, float taxRate, float maintenanceFee)
    {
        float floatToReturn = 0;

        floatToReturn = Mathf.Round(grossProfit * ((100 - (platformCut + taxRate + maintenanceFee)) / 100));

        return floatToReturn;
    }
    public void DisplaySummary()
    {
        steemGrossProfitText.text = "$"+steemGrossProfit.ToString();
        epikGrossProfitText.text = "$" + epikGrossProfit.ToString();
        pearGrossProfitText.text = "$" + pearGrossProfit.ToString();
        cyborgGrossProfitText.text = "$" + cyborgGrossProfit.ToString();
        playBoxGrossProfitText.text = "$" + playBoxGrossProfit.ToString();
        xStationGrossProfitText.text = "$" + xStationGrossProfit.ToString();

        if (steemNetProfit>0)
        {
            steemNetProfitText.text = "$" + steemNetProfit.ToString();
        }
        else
        {
            steemNetProfitText.text = "";

        }

        if (epikNetProfit > 0)
        {
            epikNetProfitText.text = "$" + epikNetProfit.ToString();
        }
        else
        {
            epikNetProfitText.text = "";

        }
        if (pearNetProfit > 0)
        {
            pearNetProfitText.text = "$" + pearNetProfit.ToString();
        }
        else
        {
            pearNetProfitText.text = "";

        }
        if (cyborgNetProfit > 0)
        {
            cyborgNetProfitText.text = "$" + cyborgNetProfit.ToString();
        }
        else
        {
            cyborgNetProfitText.text = "";

        }
        if (playBoxNetProfit > 0)
        {
            playBoxNetProfitText.text = "$" + playBoxNetProfit.ToString();
        }
        else
        {
            playBoxNetProfitText.text = "";

        }
        if (xStationNetProfit > 0)
        {
            xStationNetProfitText.text = "$" + xStationNetProfit.ToString();
        }
        else
        {
            xStationNetProfitText.text = "";

        }


        steemPlatformCutText.text = gameController.steemPlatformCut.ToString() + "%";
        epikPlatformCutText.text = gameController.epikPlatformCut.ToString() + "%";
        pearPlatformCutText.text = gameController.pearPlatformCut.ToString() + "%";
        cyborgPlatformCutText.text = gameController.cyborgPlatformCut.ToString() + "%";
        playBoxPlatformCutText.text = gameController.playBoxPlatformCut.ToString() + "%";
        xStationPlatformCutText.text = gameController.xStationPlatformCut.ToString() + "%";


        steemTaxesText.text = taxRate.ToString() + "%";
        epikTaxesText.text = taxRate.ToString() + "%";
        pearTaxesText.text = taxRate.ToString() + "%";
        cyborgTaxesText.text = taxRate.ToString() + "%";
        playBoxTaxesText.text = taxRate.ToString() + "%";
        xStationTaxesText.text = taxRate.ToString() + "%";


        steemMaintenanceFeeText.text = gameController.steemPlatformCut.ToString() + "%";
        epikMaintenanceFeeText.text = gameController.epikPlatformCut.ToString() + "%";
        pearMaintenanceFeeText.text = gameController.pearPlatformCut.ToString() + "%";
        cyborgMaintenanceFeeText.text = gameController.cyborgPlatformCut.ToString() + "%";
        playBoxMaintenanceFeeText.text = gameController.playBoxPlatformCut.ToString() + "%";
        xStationMaintenanceFeeText.text = gameController.xStationPlatformCut.ToString() + "%";




        totalProfitText.text = "$" + totalProfit.ToString();

        mostFocusedSkillText.text = FindMostFocusedSkill();
        summaryDonutChart.SetValues(summaryDonutChart.values);


    }

    public void SetGameConceptDatatoPortfolio()
    {
         GameConcept finishedGameConcept = new GameConcept();
        finishedGameConcept = player.currentGame;

        finishedGameConcept.steemUnitsSold=steemUnitsSold;
        finishedGameConcept.epikUnitsSold = epikUnitsSold;
        finishedGameConcept.pearlUnitsSold = pearUnitsSold;
        finishedGameConcept.cyborgUnitsSold = cyborgUnitsSold;
        finishedGameConcept.playBoxUnitsSold = playBoxUnitsSold;
        finishedGameConcept.xStationUnitsSold = xStationUnitsSold;

        finishedGameConcept.totalUnitsSold=totalUnitsSold;

        finishedGameConcept.isReleased=true;


        finishedGameConcept.onSteem=prepareForReleasePanel.isOnSteem;


        finishedGameConcept.onEpik = prepareForReleasePanel.isOnEpik;


        finishedGameConcept.onPear = prepareForReleasePanel.isOnPear;


        finishedGameConcept.onCyborg = prepareForReleasePanel.isOnCyborg;


        finishedGameConcept.onPlayBox = prepareForReleasePanel.isOnPlayBox;


        finishedGameConcept.onXStation = prepareForReleasePanel.isOnXStation;

        if (isNoStar)
        {
            player.popularity = 0;
            finishedGameConcept.popularity = 0;
        }
        else if (isOneStar)
        {
            player.popularity = 1;
            finishedGameConcept.popularity = 1;
        }
        else if (isTwoStar)
        {
            player.popularity = 2;
            finishedGameConcept.popularity = 2;
        }
        else if (isThreeStar)
        {
            player.popularity = 3;
            finishedGameConcept.popularity = 3;
        }
        else if (isFourStar)
        {
            player.popularity = 4;
            finishedGameConcept.popularity = 4;
        }
        else if (isFiveStar)
        {
            player.popularity = 5;
            finishedGameConcept.popularity = 5;
        }
        player.gamePortfolio.Add(finishedGameConcept);
    }
    public void StartNextGame()
    {
        player.soundManager.PlayButton2Sound();
        player.cash = player.cash + totalProfit;
        player.playerLevel++; 
        SetGameConceptDatatoPortfolio();
        if (addModelingPoint)
        {
            player.modelingSkill++;
        }
        if (addCodingPoint)
        {
            player.codingSkill++;

        }
        if (AddDesignPoint)
        {
            player.designSkill++;
        }
        if (addMarketingPoint)
        {
            player.marketingSkill++;
        }
        gameController.SaveGame();
        this.gameObject.SetActive(false);
        miniGamePanel.SetActive(false);
        prepareForReleasePanel.gameObject.SetActive(false);
        buildAGamePanel.ResetBuidAGameData();
        chooseAGamePanel.SetActive(true);
   



    }
}


