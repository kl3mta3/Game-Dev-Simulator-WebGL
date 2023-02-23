using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrepareForReleasePanel : MonoBehaviour
{
    [SerializeField]
    internal Player player;

    [SerializeField]
    internal GameController gameController;

    [SerializeField]
    internal GameObject keyboardPanel;

    // for Platform choice 

    [SerializeField]
    internal Toggle steemToggle;
    [SerializeField]
    internal Toggle epikToggle;
    [SerializeField]
    internal Toggle pearToggle;
    [SerializeField]
    internal Toggle cyborgToggle;
    [SerializeField]
    internal Toggle playBoxToggle;
    [SerializeField]
    internal Toggle xStationToggle;

    [SerializeField]
    internal TextMeshProUGUI steemCostText;
    [SerializeField]
    internal TextMeshProUGUI epikCostText;
    [SerializeField]
    internal TextMeshProUGUI pearCostText;
    [SerializeField]
    internal TextMeshProUGUI cyborgCostText;
    [SerializeField]
    internal TextMeshProUGUI playBoxCostText;
    [SerializeField]
    internal TextMeshProUGUI xStationCostText;

    internal bool isOnSteem;
    internal bool isOnEpik;
    internal bool isOnPear;
    internal bool isOnCyborg;
    internal bool isOnPlayBox;
    internal bool isOnXStation;

    internal bool keyboardOpen = false;

    //internal bool[] platformBools = new bool[6] { isOnSteem, isOnEpik, isOnPear, isOnCyborg, isOnPlayBox, isOnXStation };
    internal List<bool> platformBoolsList = new List<bool>();

    //for Marketing
    //[SerializeField]
    internal Vector3 setBudgetPopUpLocation;
    [SerializeField]
    internal Vector3 setBudgetPoolLocation;
    [SerializeField]
    internal GameObject setMarketingBudgetPanel;
    [SerializeField]
    internal TMP_InputField marketingBudgetInput;
    [SerializeField]
    internal TextMeshProUGUI availableMarketingBudgetText;

    [SerializeField]
    internal TextMeshProUGUI currentFaceFlyerBudgetText;
    [SerializeField]
    internal TextMeshProUGUI currentTikTikBudgetText;
    [SerializeField]
    internal TextMeshProUGUI currentBoogleBudgetText;
    [SerializeField]
    internal TextMeshProUGUI currentEweTubeBudgetText;

    [SerializeField]
    internal Slider faceFlyerSlider;
    [SerializeField]
    internal Slider tikTikSlider;
    [SerializeField]
    internal Slider boogleSlider;
    [SerializeField]
    internal Slider eweTubeSlider;


    internal float faceFlyerMarketingPoints;

    internal float tikTikMarketingPoints;

    internal float boogleMarketingPoints;

    internal float eweTubeMarketingPoints;



    internal float playerFaceFlyerBudget;
    internal float playerTikTikBudget;
    internal float playerBoogleBudget;
    internal float playerEweTubeBudget;

    internal float playerKidsPrediction;
    internal float playerTeensPrediction;
    internal float playerCollegePrediction;
    internal float playerAdultsPrediction;
    internal float playerBoomersPrediction;


    internal float marketingBudget;
    internal float availablemarketingPoints;
    internal float currentmarketingPointsUsed;

    internal bool marketingBudgetSet = false;


    [SerializeField]
    internal float currentMaxMarketingBudget;
    
    private TouchScreenKeyboard keyboard;

    //for Demographic 

    [SerializeField]
    internal float DemographicPointsBase;

    internal float availableDemographicPoints;
    internal float currentDemographicPointsUsed;

    [SerializeField]
    internal TextMeshProUGUI currentKidsDemographicText;
    [SerializeField]
    internal TextMeshProUGUI currentTeensDemographicText;
    [SerializeField]
    internal TextMeshProUGUI currentCollegeDemographicText;
    [SerializeField]
    internal TextMeshProUGUI currentAdultsDemographicText;
    [SerializeField]
    internal TextMeshProUGUI currentBoomerDemographicText;

    [SerializeField]
    internal Slider kidsSlider;
    [SerializeField]
    internal Slider teensSlider;
    [SerializeField]
    internal Slider collegeSlider;
    [SerializeField]
    internal Slider adultsSlider;
    [SerializeField]
    internal Slider boomerSlider;


    internal float kidsDemographicPoints;

    internal float teensDemographicPoints;

    internal float collegeDemographicPoints;

    internal float adultsDemographicPoints;

    internal float boomerDemographicPoints;


    internal float faceFlyerMiniGameBonus = 0f;

    internal float tikTikMiniGameBonus = 0f;

    internal float boogleMiniGameBonus = 0f;

    internal float eweTubeMiniGameBonus = 0f;

    internal float totalMiniGameBonusChances = 0f;

    internal bool keyboardActive = false;

    public void Start()
    {
        DisplayPlatformData();
    }
    public void OnEnable()
    {
        setBudgetPopUpLocation = (Screen.width / 2) * Vector3.right + (Screen.height / 2) * Vector3.up;
        
        ResetMarketing();
        ResetDemographic();
        ResetPlatforms();

    }

    public void Update()
    {
        // UpdateMarketingSlider();


        if(keyboardActive)
        {


            onChangeOSK();
        }
    }
    ///MarketingMethods
    public void SetMarketingBudget()
    {

        //ResetMarketing();

        if (marketingBudgetInput.text != "" && !marketingBudgetSet)
        {
            if (float.Parse(marketingBudgetInput.text) <= player.cash)
            {
                marketingBudget = float.Parse(marketingBudgetInput.text);

                player.loseCash(marketingBudget);
                availablemarketingPoints = marketingBudget - currentmarketingPointsUsed;//
                availableMarketingBudgetText.text = "$" + marketingBudget.ToString();
                marketingBudgetSet = true;
                CloseSetMarketingPanel();

            }
            else
            {
                marketingBudgetInput.text = "Not Enouch Cash";
            }
        }
    }
    public void OpenSetMarketingPanel()
    {
        if (marketingBudgetSet)
        {
            player.AddCash(marketingBudget);
            ResetMarketing();
            // Debug.Log("marketingBudgetSet = true");

            setMarketingBudgetPanel.transform.position = setBudgetPopUpLocation;
            setMarketingBudgetPanel.SetActive(true);
        }
        else if (!marketingBudgetSet)
        {
            //Debug.Log("marketingBudgetSet = false");
            setMarketingBudgetPanel.transform.position = setBudgetPopUpLocation;
            setMarketingBudgetPanel.SetActive(true);


        }
    }

    public void CloseSetMarketingPanel()
    {
        setMarketingBudgetPanel.transform.position = setBudgetPoolLocation;
        setMarketingBudgetPanel.SetActive(false);
    }
    public void UpdateMarketingSlider()
    {
        currentmarketingPointsUsed = faceFlyerSlider.value + (tikTikSlider.value) + (boogleSlider.value) + (eweTubeSlider.value);
        availablemarketingPoints = marketingBudget - currentmarketingPointsUsed;
        DisplayMarketingBudget();

        //eweTubeMarketingPoints = (eweTubeSlider.value);
        //eweTubeSlider.maxValue = availablemarketingPoints + (eweTubeSlider.value);

        //boogleMarketingPoints = (boogleSlider.value);
        //boogleSlider.maxValue = availablemarketingPoints + (boogleSlider.value);

        //tikTikMarketingPoints = (tikTikSlider.value);
        //tikTikSlider.maxValue = availablemarketingPoints + (tikTikSlider.value);

        //faceFlyerMarketingPoints = (faceFlyerSlider.value);
        //faceFlyerSlider.maxValue = availablemarketingPoints + (faceFlyerSlider.value);


    }
    

    public void UpdateFaceFlyerSlider()
    {
        currentmarketingPointsUsed = faceFlyerSlider.value + (tikTikSlider.value) + (boogleSlider.value) + (eweTubeSlider.value);
        availablemarketingPoints = marketingBudget - currentmarketingPointsUsed;
        DisplayMarketingBudget();

        faceFlyerMarketingPoints = (faceFlyerSlider.value);
        faceFlyerSlider.maxValue = availablemarketingPoints + (faceFlyerSlider.value);


    }

    public void UpdateTikTikSlider()
    {
        currentmarketingPointsUsed = faceFlyerSlider.value + (tikTikSlider.value) + (boogleSlider.value) + (eweTubeSlider.value);
        availablemarketingPoints = marketingBudget - currentmarketingPointsUsed;
        DisplayMarketingBudget();

        tikTikMarketingPoints = (tikTikSlider.value);
        tikTikSlider.maxValue = availablemarketingPoints + (tikTikSlider.value);




    }

    public void UpdateBoogleSlider()
    {
        currentmarketingPointsUsed = faceFlyerSlider.value + (tikTikSlider.value) + (boogleSlider.value) + (eweTubeSlider.value);
        availablemarketingPoints = marketingBudget - currentmarketingPointsUsed;
        DisplayMarketingBudget();

        boogleMarketingPoints = (boogleSlider.value);
        boogleSlider.maxValue = availablemarketingPoints + (boogleSlider.value);


    }

    public void UpdateEweTubeSlider()
    {
        currentmarketingPointsUsed = faceFlyerSlider.value + (tikTikSlider.value) + (boogleSlider.value) + (eweTubeSlider.value);
        availablemarketingPoints = marketingBudget - currentmarketingPointsUsed;
        DisplayMarketingBudget();

        eweTubeMarketingPoints = (eweTubeSlider.value);
        eweTubeSlider.maxValue = availablemarketingPoints + (eweTubeSlider.value);



    }

    public void OpenOSK()
    {
        if (Application.isMobilePlatform)
        {
            keyboard = TouchScreenKeyboard.Open(marketingBudgetInput.text, TouchScreenKeyboardType.Default, false, false, false, false, "Enter amount");
            keyboardActive = true;
        }
    }


    public void CloseOSK()
    {
        if (Application.isMobilePlatform)
        {
            
            keyboardActive = false;
        }
    }


    public void onChangeOSK()
    {
    
             marketingBudgetInput.text= keyboard.text;
           
        
    }
    public void DisplayMarketingBudget()
    {
        currentFaceFlyerBudgetText.text = "$" + Mathf.Round(faceFlyerSlider.value).ToString();
        playerFaceFlyerBudget = Mathf.Round(faceFlyerSlider.value);
        currentTikTikBudgetText.text = "$" + Mathf.Round(tikTikSlider.value).ToString();
        playerTikTikBudget = Mathf.Round(tikTikSlider.value);
        currentBoogleBudgetText.text = "$" + Mathf.Round(boogleSlider.value).ToString();
        playerBoogleBudget = Mathf.Round(boogleSlider.value);
        currentEweTubeBudgetText.text = "$" + Mathf.Round(eweTubeSlider.value).ToString();
        playerEweTubeBudget = Mathf.Round(eweTubeSlider.value);

        availableMarketingBudgetText.text = "$" + Mathf.Round(availablemarketingPoints).ToString();

    }
    public void ResetMarketing()
    {
        //if (marketingBudgetSet)
        //{
        //    Debug.Log("Marketing Panel Opened While Set Adding Cash/Reset");
        //    player.AddCash(marketingBudget);

        //}

        eweTubeSlider.value = 0;
        boogleSlider.value = 0;
        tikTikSlider.value = 0;
        faceFlyerSlider.value = 0;


        marketingBudget = 0;
        currentDemographicPointsUsed = 0;
        //availablemarketingPoints=0;


        faceFlyerMarketingPoints = 0;
        tikTikMarketingPoints = 0;
        boogleMarketingPoints = 0;
        eweTubeMarketingPoints = 0;

        faceFlyerMiniGameBonus = 0f;
        tikTikMiniGameBonus = 0f;
        boogleMiniGameBonus = 0f;
        eweTubeMiniGameBonus = 0f;
        totalMiniGameBonusChances = 0f;
        availableMarketingBudgetText.text = "$" + marketingBudget.ToString();
        marketingBudgetInput.text = "";
        marketingBudgetSet = false;

        playerKidsPrediction = 0;
        playerTeensPrediction = 0;
        playerCollegePrediction = 0;
        playerAdultsPrediction = 0;
        playerBoomersPrediction = 0;


        playerFaceFlyerBudget = 0;
        playerTikTikBudget = 0;
        playerBoogleBudget = 0;
        playerEweTubeBudget = 0;
        availablemarketingPoints = marketingBudget - currentmarketingPointsUsed;//
    }

    /// Demographic Methods


    public void UpdateDemographicSlider()
    {
        currentDemographicPointsUsed = kidsSlider.value + teensSlider.value + collegeSlider.value + adultsSlider.value + boomerSlider.value;
        availableDemographicPoints = DemographicPointsBase - currentDemographicPointsUsed;

        kidsSlider.maxValue = availableDemographicPoints + kidsSlider.value;
        kidsDemographicPoints = kidsSlider.value;
        teensSlider.maxValue = availableDemographicPoints + teensSlider.value;
        teensDemographicPoints = teensSlider.value;
        collegeSlider.maxValue = availableDemographicPoints + collegeSlider.value;
        collegeDemographicPoints = collegeSlider.value;
        adultsSlider.maxValue = availableDemographicPoints + adultsSlider.value;
        adultsDemographicPoints = adultsSlider.value;
        boomerSlider.maxValue = availableDemographicPoints + boomerSlider.value;
        boomerDemographicPoints = boomerSlider.value;
        DisplayDeomgraphicData();

    }
    public void DisplayDeomgraphicData()
    {
        currentKidsDemographicText.text = Mathf.Round(kidsSlider.value).ToString() + "%";
        currentTeensDemographicText.text = Mathf.Round(teensSlider.value).ToString() + "%";
        currentCollegeDemographicText.text = Mathf.Round(collegeSlider.value).ToString() + "%";
        currentAdultsDemographicText.text = Mathf.Round(adultsSlider.value).ToString() + "%";
        currentBoomerDemographicText.text = Mathf.Round(boomerSlider.value).ToString() + "%";

    }
    public void ResetDemographic()
    {

        kidsSlider.value = 0;
        teensSlider.value = 0;
        collegeSlider.value = 0;
        adultsSlider.value = 0;
        boomerSlider.value = 0;

        kidsDemographicPoints = 0;
        teensDemographicPoints = 0;
        collegeDemographicPoints = 0;
        adultsDemographicPoints = 0;
        boomerDemographicPoints = 0;

        availableDemographicPoints = 0;
        currentDemographicPointsUsed = 0;

    }

    ///Plarform Methods

    public void SteemToggle()
    {
        if (player.cash >= gameController.steemCost)
        {
            if (steemToggle.isOn)
            {
                isOnSteem = true;
                player.loseCash(gameController.steemCost);
                platformBoolsList.Add(isOnSteem);
            }
            else
            {
                isOnSteem = false;
                player.AddCash(gameController.steemCost);
                platformBoolsList.Remove(isOnSteem);
                ;
            }
        }
        else if (player.cash < gameController.steemCost && isOnSteem)
        {
            isOnSteem = false;
            steemToggle.isOn = false;
            player.AddCash(gameController.steemCost);
            platformBoolsList.Remove(isOnSteem);


        }
        else if (player.cash < gameController.steemCost && !isOnSteem)
        {
            steemToggle.isOn = false;

        }

    }
    public void EpikToggle()
    {
        if (player.cash >= gameController.epikCost)
        {
            if (epikToggle.isOn)
            {
                isOnEpik = true;
                player.loseCash(gameController.epikCost);
                platformBoolsList.Add(isOnEpik);
            }
            else
            {
                isOnEpik = false;
                player.AddCash(gameController.epikCost);
                platformBoolsList.Remove(isOnEpik);
            }
        }
        else if (player.cash < gameController.epikCost && isOnEpik)
        {
            isOnEpik = false;
            epikToggle.isOn = false;
            player.AddCash(gameController.epikCost);
            platformBoolsList.Remove(isOnEpik);

        }
        else if (player.cash < gameController.epikCost && !isOnEpik)
        {
            epikToggle.isOn = false;

        }


    }
    public void PearToggle()
    {
        if (player.cash >= gameController.pearCost)
        {
            if (pearToggle.isOn)
            {
                isOnPear = true;
                player.loseCash(gameController.pearCost);
                platformBoolsList.Add(isOnPear);
            }
            else
            {
                isOnPear = false;
                player.AddCash(gameController.pearCost);
                platformBoolsList.Remove(isOnPear);
            }
        }
        else if (player.cash < gameController.pearCost && isOnPear)
        {
            isOnPear = false;
            pearToggle.isOn = false;
            player.AddCash(gameController.pearCost);
            platformBoolsList.Remove(isOnPear);

        }
        else if (player.cash < gameController.pearCost && !isOnPear)
        {
            pearToggle.isOn = false;

        }

    }
    public void CyborgToggle()
    {
        if (player.cash >= gameController.cyborgCost)
        {
            if (cyborgToggle.isOn)
            {
                isOnCyborg = true;
                player.loseCash(gameController.cyborgCost);
                platformBoolsList.Add(isOnCyborg);
            }
            else
            {
                isOnCyborg = false;
                player.AddCash(gameController.cyborgCost);
                platformBoolsList.Remove(isOnCyborg);
            }
        }
        else if (player.cash < gameController.cyborgCost && isOnCyborg)
        {
            isOnCyborg = false;
            cyborgToggle.isOn = false;
            player.AddCash(gameController.cyborgCost);
            platformBoolsList.Remove(isOnCyborg);

        }
        else if (player.cash < gameController.cyborgCost && !isOnCyborg)
        {
            cyborgToggle.isOn = false;

        }

    }
    public void PlayBoxToggle()
    {
        if (player.cash >= gameController.playBoxCost)
        {
            if (playBoxToggle.isOn)
            {
                isOnPlayBox = true;
                player.loseCash(gameController.playBoxCost);
                platformBoolsList.Add(isOnPlayBox);

            }
            else
            {
                isOnPlayBox = false;
                player.AddCash(gameController.playBoxCost);
                platformBoolsList.Remove(isOnPlayBox);
            }
        }
        else if (player.cash < gameController.playBoxCost && isOnPlayBox)
        {
            isOnPlayBox = false;
            playBoxToggle.isOn = false;
            player.AddCash(gameController.playBoxCost);
            platformBoolsList.Remove(isOnPlayBox);

        }
        else if (player.cash < gameController.playBoxCost && !isOnPlayBox)
        {
            playBoxToggle.isOn = false;

        }

    }
    public void XStationToggle()
    {
        if (player.cash >= gameController.xStationCost)
        {
            if (xStationToggle.isOn)
            {
                isOnXStation = true;
                player.loseCash(gameController.xStationCost);
                platformBoolsList.Add(isOnXStation);
            }
            else
            {
                isOnXStation = false;
                player.AddCash(gameController.xStationCost);
                platformBoolsList.Remove(isOnXStation);
            }
        }
        else if (player.cash < gameController.xStationCost && isOnXStation)
        {
            isOnXStation = false;
            xStationToggle.isOn = false;
            player.AddCash(gameController.xStationCost);
            platformBoolsList.Remove(isOnXStation);

        }
        else if (player.cash < gameController.xStationCost && !isOnXStation)
        {
            xStationToggle.isOn = false;

        }

    }
    public void DisplayPlatformData()
    {


        steemCostText.text = "($" + gameController.steemCost.ToString() + ")";
        epikCostText.text = "($" + gameController.epikCost.ToString() + ")";
        pearCostText.text = "($" + gameController.pearCost.ToString() + ")";
        cyborgCostText.text = "($" + gameController.cyborgCost.ToString() + ")";
        playBoxCostText.text = "($" + gameController.playBoxCost.ToString() + ")";
        xStationCostText.text = "($" + gameController.xStationCost.ToString() + ")";
    }
    public float TotalPlatfomrsReleasedOn()
    {
        float totalPlatforms = 0;
        totalPlatforms = platformBoolsList.Count;
        return totalPlatforms;
    }

    public void ResetPlatforms()
    {
        steemToggle.isOn = false;
        epikToggle.isOn = false;
        pearToggle.isOn = false;
        cyborgToggle.isOn = false;
        playBoxToggle.isOn = false;
        xStationToggle.isOn = false;
        isOnSteem = false;
        isOnEpik = false;
        isOnPear = false;
        isOnCyborg = false;
        isOnPlayBox = false;
        isOnXStation = false;
        platformBoolsList.Clear();
    }

    public void ToggleKeyboard()
    {

        keyboardOpen = !keyboardOpen;

        if (keyboardOpen)
        {
            keyboardPanel.SetActive(true);
        }
        else
        {
            keyboardPanel.SetActive(false);
        }


    }


    public void OnePressed()
    {

        marketingBudgetInput.text += "1";
    }
    public void TwoPressed()
    {
        marketingBudgetInput.text += "2";

    }
    public void ThreePressed()
    {
        marketingBudgetInput.text += "3";

    }
    public void FOurPressed()
    {
        marketingBudgetInput.text += "4";

    }
    public void FivePressed()
    {

        marketingBudgetInput.text += "5";
    }
    public void SixPressed()
    {
        marketingBudgetInput.text += "6";

    }
    public void SevenPressed()
    {
        marketingBudgetInput.text += "7";

    }
    public void EightPressed()
    {
        marketingBudgetInput.text += "8";

    }
    public void NinePressed()
    {
        marketingBudgetInput.text += "9";

    }
    public void ZeroPressed()
    {
        marketingBudgetInput.text += "0";

    }
    public void BackPressed()
    {
        if (marketingBudgetInput.text.Length > 0)
        {
            marketingBudgetInput.text = marketingBudgetInput.text.Substring(0, marketingBudgetInput.text.Length - 1);
        }
    }
}
