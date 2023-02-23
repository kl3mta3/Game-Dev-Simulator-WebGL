using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;


public class BuildAGamePanel : MonoBehaviour
{
    [SerializeField]
    internal Player player;

    [SerializeField]
    internal float autoProgressSlowRate = 0;

    [SerializeField]
    internal GameConcept currentGameConcept;

    [SerializeField]
    internal GameConceptPanel gameConceptPanel;

    [SerializeField]
    internal Button chooseButton;

    [SerializeField]
    internal TextMeshProUGUI projectNameText;

    [SerializeField]
    internal TextMeshProUGUI projectCostText;

    [SerializeField]
    internal TextMeshProUGUI modelingProgressText;
    [SerializeField]
    internal TextMeshProUGUI codingProgressText;
    [SerializeField]
    internal TextMeshProUGUI designProgressText;
    [SerializeField]
    internal TextMeshProUGUI marketingProgressText;

    [SerializeField]
    internal TextMeshProUGUI progressUpdateText;


    [SerializeField]
    internal Button releaseButton;

    [SerializeField]
    internal Image modelingStatBar;
    [SerializeField]
    internal Image codingStatBar;
    [SerializeField]
    internal Image designStatBar;
    [SerializeField]
    internal Image marketingStatBar;

    //stats for actual building the game
    [SerializeField]
    internal float baseConceptTime;

    [SerializeField]
    internal float totalmodelingSkill;
    [SerializeField]
    internal float totalcodingSkill;
    [SerializeField]
    internal float totaldesignSkill;
    [SerializeField]
    internal float totalmarketingSkill;


    [SerializeField]
    internal float baseModelingSkill;
    [SerializeField]
    internal float baseCodingSkill;
    [SerializeField]
    internal float baseDesignSkill;
    [SerializeField]
    internal float baseMarketingSkill;
    [SerializeField]

    internal float totalmodelingProgress;
    [SerializeField]
    internal float totalcodingProgress;
    [SerializeField]
    internal float totaldesignProgress;
    [SerializeField]
    internal float totalmarketingProgress;

    [SerializeField]
    internal float currentmodelingProgress;
    [SerializeField]
    internal float currentcodingProgress;
    [SerializeField]
    internal float currentdesignProgress;
    [SerializeField]
    internal float currentmarketingProgress;


    [SerializeField]
    internal float totalmodelingProgressPercent;
    [SerializeField]
    internal float totalcodingProgressPercent;
    [SerializeField]
    internal float totaldesignProgressPercent;
    [SerializeField]
    internal float totalmarketingProgressPercent;


    [SerializeField]
    internal float totalCurrentProgress;
    [SerializeField]
    internal float totalProjectTime;
    [SerializeField]
    internal float totalmodelingDificulty;
    [SerializeField]
    internal float totalcodingDificulty;
    [SerializeField]
    internal float totaldesignDificulty;
    [SerializeField]
    internal float totalmarketingDificulty;
    [SerializeField]
    internal float totalDificulty;

    [SerializeField]
    internal float modelingClicks;
    [SerializeField]
    internal float codingClicks;
    [SerializeField]
    internal float designClicks;
    [SerializeField]
    internal float marketingClicks;

    internal float totalClick;

    internal float[] gameCreationClicksArray = new float[5];



    internal float designDisplaytotal;
    internal float marketingDisplaytotal;
    internal float codingDisplaytotal;
    internal float modelingDisplaytotal;

    //internal float modelingClicks;
    //internal  float codingClicks;
    //internal float designClicks;
    //internal  float marketingClicks;
    //internal  float totalClick;

    internal float totalTeamSize = 1;



   
    [SerializeField]
    internal bool panelSet = false;


    [SerializeField]
    internal bool modelingDone = false;
    [SerializeField]
    internal bool codingDone = false;
    [SerializeField]
    internal bool designDone = false;
    [SerializeField]
    internal bool marketingDone = false;

    [SerializeField]
    internal bool marketingClicked;
    [SerializeField]
    internal bool designClicked;
    [SerializeField]
    internal bool codingClicked;
    [SerializeField]
    internal bool modelingClicked ;

    [SerializeField]
    internal bool progressOverTime = true;
    [SerializeField]
    internal bool progressionRunning=false;

    [SerializeField]
    internal bool canPressButton = true;
    [SerializeField]
    internal bool gameBuilt = false;

    //internal bool firstRun = true;
    public void Start()
    {
        gameCreationClicksArray[0] = modelingClicks;
        gameCreationClicksArray[1] = codingClicks;
        gameCreationClicksArray[2] = designClicks;
        gameCreationClicksArray[3] = marketingClicks;
        gameCreationClicksArray[4] = totalClick;
    }

    public void OnEnable()
    {

        //ResetBuidAGameData();
        StartCoroutine(SetUpPanel());
        chooseButton.gameObject.SetActive(false);
        //StartCoroutine(ButtonReset());

        marketingDisplaytotal = totalmarketingProgressPercent;
        designDisplaytotal = totaldesignProgressPercent;
        codingDisplaytotal = totalcodingProgressPercent;
        modelingDisplaytotal = totalmodelingProgressPercent;
    }
    public void OnDisable()
    {
        StopCoroutine(SetUpPanel());
        StopCoroutine(ButtonReset());
    }
    public void ResetBuidAGameData()
    {

        progressionRunning = false;
        currentGameConcept = null;
        projectNameText.text = "";

        projectCostText.text = "";

        modelingProgressText.text = "";
        codingProgressText.text = "";

        progressUpdateText.text = "";

        releaseButton.interactable = false;

        modelingStatBar.fillAmount = 0f;
        codingStatBar.fillAmount = 0f;
        designStatBar.fillAmount = 0f;
        marketingStatBar.fillAmount = 0f;



        baseConceptTime = 0;


        totalmodelingSkill = 0;

        totalcodingSkill = 0;

        totaldesignSkill = 0;
        totalmarketingSkill = 0;



        baseModelingSkill = 0;

        baseCodingSkill = 0;

        baseDesignSkill = 0;

        baseMarketingSkill = 0;


        totalmodelingProgress = 0;

        totalcodingProgress = 0;

        totaldesignProgress = 0;

        totalmarketingProgress = 0;


        currentmodelingProgress = 0;

        currentcodingProgress = 0;

        currentdesignProgress = 0;

        currentmarketingProgress = 0;



        totalmodelingProgressPercent = 0;

        totalcodingProgressPercent = 0;

        totaldesignProgressPercent = 0;

        totalmarketingProgressPercent = 0;

        totalTeamSize = 1;

        totalCurrentProgress = 0;
        totalProjectTime = 0;
        totalmodelingDificulty = 0;
        totalcodingDificulty = 0;
        totaldesignDificulty = 0;
        totalmarketingDificulty = 0;
        totalDificulty = 0;


        modelingClicks = 0;
        codingClicks = 0;
        designClicks = 0;
        marketingClicks = 0;
        totalClick = 0;

        panelSet = false;
        modelingDone = false;
        codingDone = false;
        designDone = false;
        marketingDone = false;
        canPressButton = true;
        gameBuilt = false;
    }

    public void Update()
    {
        totalmodelingSkill = player.modelingSkill + player.modelingSkillBoost;

        totalcodingSkill = player.codingSkill + player.codingSkillBoost;

        totaldesignSkill = player.designSkill + player.designSkillBoost;

        totalmarketingSkill = player.marketingSkill + player.marketingSkillBoost;
        
        modelingDisplaytotal = totalmodelingProgressPercent - currentmodelingProgress;
        modelingStatBar.fillAmount = (totalmodelingProgressPercent - currentmodelingProgress) / totalProjectTime;

        codingDisplaytotal = totalcodingProgressPercent - currentcodingProgress;
        codingStatBar.fillAmount = codingDisplaytotal / totalProjectTime;

        designDisplaytotal = totaldesignProgressPercent - currentdesignProgress;
        designStatBar.fillAmount = designDisplaytotal / totalProjectTime;


        marketingDisplaytotal = totalmarketingProgressPercent - currentmarketingProgress;
        marketingStatBar.fillAmount = marketingDisplaytotal / totalProjectTime;
        if (panelSet && !gameBuilt)
        {
            if (!progressionRunning)
            {
                IncreaseCurrentProgressOverTime();
            }


            if (currentmodelingProgress > 0.1)
            {
                modelingProgressText.text = (totalmodelingProgressPercent - currentmodelingProgress).ToString("F0");/*+ " / " + totalProjectTime;*/
            }
            else 
            {
                modelingProgressText.text = "0";
            }

            if (codingDisplaytotal > 0.1)
            {
                codingProgressText.text = codingDisplaytotal.ToString("F0");/*+ " / " + totalProjectTime;*/
            }
            else
            {
                codingProgressText.text = "0";
            }

            if (designDisplaytotal > 0.1)
            {
                designProgressText.text = (designDisplaytotal).ToString("F0");/*+ " / " + totalProjectTime;*/
            }
            else
            {
                designProgressText.text = "0";
            }

            if (marketingDisplaytotal > 0.1)
            {
                marketingProgressText.text = (marketingDisplaytotal).ToString("F0");/*+ " / " + totalProjectTime;*/
            }
            else
            {
                marketingProgressText.text = "0";
            }
        }



    }


    public void CheckForGameDone()
    {


        if ((totalmodelingProgressPercent - currentmodelingProgress) < 1)
        {
            modelingDone = true;
        }




        if ((totalcodingProgressPercent - currentcodingProgress) < 1)
        {
            codingDone = true;
        }




        if ((totaldesignProgressPercent - currentdesignProgress) < 1)
        {
            designDone = true;
        }


        if ((totalmarketingProgressPercent - currentmarketingProgress) < 1)
        {
            marketingDone = true;
        }


        if (marketingDone && designDone && codingDone && modelingDone)
        {

            gameBuilt = true;
            releaseButton.interactable = true;

        }



    }


    public void ManuallyIncreaseModeling()
    {
        if (!modelingClicked && canPressButton)
        {
            modelingClicked = true;
            canPressButton = false;
            StartCoroutine(ButtonReset());
        }
    }
    public void ManuallyIncreaseCoding()
    {
        if (!codingClicked  && canPressButton)
        {
            codingClicked = true;
            canPressButton = false;
            StartCoroutine(ButtonReset());
        }
    }
    public void ManuallyIncreasDesign()
    {
        if (!designClicked &&canPressButton)
        {
            designClicked = true;
            canPressButton = false;
            StartCoroutine(ButtonReset());
        }
    }
    public void ManuallyIncreaseMarketing()
    {
        if (!marketingClicked &&canPressButton)
        {
            marketingClicked = true;
            canPressButton = false;
            StartCoroutine(ButtonReset());
        }
    }


    public bool CheckIfButtonPressed()
    {
        if (marketingClicked || designClicked || codingClicked || modelingClicked)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void ButtonPressed()
    {

        if (totalmodelingProgressPercent >= currentmodelingProgress && currentmodelingProgress+ totalmodelingSkill >= 0 )
        {

            if (modelingClicked )
            {
            totalCurrentProgress = Mathf.Round(totalCurrentProgress + 1);

               
                modelingClicks++;
                currentmodelingProgress = (currentmodelingProgress + totalmodelingSkill) ;

                player.soundManager.PlayButton3Sound();
            
                Debug.Log("totalmodelingSkill" + totalmodelingSkill);
                

                modelingClicked = false;
            }

        }



        if (totalcodingProgressPercent >= currentcodingProgress && currentcodingProgress+ totalcodingSkill >= 0)
        {

            if (codingClicked)
            {
           totalCurrentProgress = Mathf.Round(totalCurrentProgress + 1);
                //currentcodingProgress = currentcodingProgress + totalcodingSkill;
        
                codingClicks++;
                currentcodingProgress = currentcodingProgress + totalcodingSkill ;

                player.soundManager.PlayButton3Sound();

              
                StartCoroutine(ButtonReset());

                codingClicked = false;


            }

        }



        if (totaldesignProgressPercent >= currentdesignProgress && currentdesignProgress+ totaldesignSkill >= 0)
        {


            if (designClicked)
            {
            totalCurrentProgress = Mathf.Round(totalCurrentProgress + 1);
                designClicks++;
                currentdesignProgress = currentdesignProgress + totaldesignSkill;
                player.soundManager.PlayButton3Sound();
                StartCoroutine(ButtonReset());
                designClicked = false;

            }


        }



        if ((totalmarketingProgressPercent >= currentmarketingProgress && currentmarketingProgress +totalmarketingSkill>=0))
        {
            //currentmarketingProgress += 1 * (Time.deltaTime / 2);

            if (marketingClicked)
            {
            totalCurrentProgress = Mathf.Round(totalCurrentProgress + 1);
                marketingClicks++;

                currentmarketingProgress = currentmarketingProgress + totalmarketingSkill;

                player.soundManager.PlayButton3Sound();
             
                StartCoroutine(ButtonReset());



                marketingClicked = false;
            }

        }

    }






    public void ButtonNotPressed()
    {
        if (totalmodelingProgressPercent > currentmodelingProgress && currentmodelingProgress + totalmodelingSkill >= 0)
        {
            if (progressOverTime)
            {
                totalCurrentProgress = Mathf.Round(totalCurrentProgress + 1);
                currentmodelingProgress += autoProgressSlowRate * Time.deltaTime;
            




                //marketingClicked = false;
            }
        }



        if (totalcodingProgressPercent > currentcodingProgress && currentcodingProgress + totalcodingSkill >= 0)
        {
            if (progressOverTime)
            {
                totalCurrentProgress = Mathf.Round(totalCurrentProgress + 1);
                currentcodingProgress += (autoProgressSlowRate * Time.deltaTime);


                //codingClicked = false;
            }
        }



        if (totaldesignProgressPercent > currentdesignProgress && currentdesignProgress + totaldesignSkill >= 0)
        {



            if (progressOverTime)
            {
                totalCurrentProgress = Mathf.Round(totalCurrentProgress + 1);
                currentdesignProgress += (autoProgressSlowRate * Time.deltaTime);



                //designClicked = false;

            }

        }



        if ((totalmarketingProgressPercent > currentmarketingProgress && currentmarketingProgress + totalmarketingSkill >= 0))
        {
            if (progressOverTime)
            {
                totalCurrentProgress = Mathf.Round(totalCurrentProgress + 1);
                currentmarketingProgress += (autoProgressSlowRate * Time.deltaTime);



                //marketingClicked = false;
            }

        }

        //marketingDisplaytotal = totalmarketingProgressPercent - currentmarketingProgress;
        //marketingStatBar.fillAmount = marketingDisplaytotal / totalProjectTime;
        //marketingProgressText.text = (marketingDisplaytotal).ToString("F0");/*+ " / " + totalProjectTime;*/

        //designDisplaytotal = totaldesignProgressPercent - currentdesignProgress;
        //designStatBar.fillAmount = designDisplaytotal / totalProjectTime;
        //designProgressText.text = (designDisplaytotal).ToString("F0");/*+ " / " + totalProjectTime;*/


        //codingDisplaytotal = totalcodingProgressPercent - currentcodingProgress;
        //codingStatBar.fillAmount = codingDisplaytotal / totalProjectTime;
        //codingProgressText.text = codingDisplaytotal.ToString("F0");/*+ " / " + totalProjectTime;*/

        //modelingDisplaytotal = totalmodelingProgressPercent - currentmodelingProgress;
        //modelingStatBar.fillAmount = modelingDisplaytotal / totalProjectTime;
        //modelingProgressText.text = modelingDisplaytotal.ToString("F0");/*+ " / " + totalProjectTime;*/
    }




    public void IncreaseCurrentProgressOverTime()
    {
        progressionRunning = true;
        if (CheckIfButtonPressed())
        {

            ButtonPressed();
        }
        else if (!CheckIfButtonPressed())
        {


            ButtonNotPressed();
        }
        

        totalCurrentProgress = Mathf.Round(currentmarketingProgress + currentdesignProgress + currentcodingProgress + currentmodelingProgress);

        if (totalCurrentProgress == totalProjectTime)
        {

            gameBuilt = true;
        }
        CheckForGameDone();
        progressionRunning = false;
        //StartCoroutine(CalculateProgress());

    }

    public void SetTotalSkill()
    {

        totalmodelingSkill = player.modelingSkill+player.modelingSkillBoost;

        totalcodingSkill = player.codingSkill + player.codingSkillBoost;

        totaldesignSkill = player.designSkill + player.designSkillBoost;

        totalmarketingSkill = player.marketingSkill + player.marketingSkillBoost;
        



        
        baseModelingSkill = player.modelingSkill;

        baseCodingSkill = player.codingSkill;

        baseDesignSkill = player.designSkill;

        baseMarketingSkill = player.marketingSkill;


    }
    public void SetGameDificulty()
    {

        totalmodelingDificulty = currentGameConcept.modelingDificulty-totalmodelingSkill;
        totalcodingDificulty = currentGameConcept.codingDificulty - totalcodingSkill;
        totaldesignDificulty = currentGameConcept.designDificulty - totaldesignSkill;
        totalmarketingDificulty = currentGameConcept.marketingDificulty - totalmarketingSkill;
        totalDificulty = totalmodelingDificulty + totalcodingDificulty + totaldesignDificulty+ totalmarketingDificulty;

    }
    
    public void SetProgressNeededTotals()
    {
       
        totalProjectTime = baseConceptTime + totalDificulty;

        float percentmodelingtotal = totalmodelingDificulty / totalDificulty;
        totalmodelingProgressPercent = totalProjectTime * percentmodelingtotal;

        float percentcodingtotal = totalcodingDificulty / totalDificulty;
        totalcodingProgressPercent = totalProjectTime * percentcodingtotal;

        float percentdesigntotal = totaldesignDificulty / totalDificulty;
        totaldesignProgressPercent = totalProjectTime * percentdesigntotal;

        float percentmarketingtotal = totalmarketingDificulty / totalDificulty;
        totalmarketingProgressPercent = totalProjectTime * percentmarketingtotal;


    }

    //public void ResetPanel()
    //{
    //    modelingDone = false;
    //    codingDone = false;
    //    designDone = false;
    //    marketingDone = false;
    //    releaseButton.interactable = false;
    //    gameBuilt = false;

    //    for (int i = 0; i < allFloats.Count; i++)
    //    {

    //        allFloats[i] = 0;
            
    //    }
    //    Debug.Log("Panel Reset");

    //}
    public void BuildGame()
    {
        player.gamesMade++;
        player.gamePortfolio.Add(currentGameConcept);




    }

    public IEnumerator SetUpPanel()
    {
        //if (gameBuilt)
        //{
        //    ResetPanel();

        //}
       
        yield return new WaitForSeconds(.02f);
        currentGameConcept = player.currentGame;
        gameConceptPanel.SetPanel(currentGameConcept);
        baseConceptTime = player.currentGame.devTime;
        modelingDone = false;
        codingDone = false;
        designDone = false;
        marketingDone = false;
        releaseButton.interactable = false;
        gameBuilt = false;
        projectNameText.text = player.currentGame.gameConceptName;
      
        yield return new WaitForSeconds(.01f);
        SetTotalSkill();
        yield return new WaitForSeconds(.01f);
        SetGameDificulty();
        yield return new WaitForSeconds(.01f);
        SetProgressNeededTotals();
        yield return new WaitForSeconds(.01f);
        panelSet = true;
        StopCoroutine(SetUpPanel());
    }


    public IEnumerator ButtonReset()
    {

        if (!canPressButton)
        {
            yield return new WaitForSeconds(.5f);
            //if (modelingClicked)
            //{
            //    modelingClicked = false;

            //}

            //if(codingClicked)
            //{
            //    codingClicked = false;
            //}
            //if(designClicked)
            //{

            //    designClicked = false;

            //}
            //if(marketingClicked)
            //{



            //    marketingClicked = false;
            //}
            canPressButton = true;
            StopCoroutine(ButtonReset());
        }




    }

    IEnumerator CalculateProgress()
    {
        
        progressionRunning = true;
        if(CheckIfButtonPressed())
        {

            ButtonPressed();
        }
        else if (!CheckIfButtonPressed())
        {


            ButtonNotPressed();
        }
        yield return new WaitForSeconds(.01f);

        totalCurrentProgress = Mathf.Round(currentmarketingProgress + currentdesignProgress + currentcodingProgress + currentmodelingProgress);

        if (totalCurrentProgress == totalProjectTime)
        {

            gameBuilt = true;
        }
        CheckForGameDone();

        yield return new WaitForSeconds(.01f);
        progressionRunning = false;
       // modelingClicked = false;
        StopCoroutine(CalculateProgress());
    }
}
