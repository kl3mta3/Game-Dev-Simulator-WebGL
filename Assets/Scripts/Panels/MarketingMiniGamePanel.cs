using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class MarketingMiniGamePanel : MonoBehaviour
{

    [SerializeField]
    internal PrepareForReleasePanel PrepareForReleasePanel;

    [SerializeField]
    internal GameObject resultsPanel;

    [SerializeField]
    internal TextMeshProUGUI timerDisplayText;
    [SerializeField]
    internal Player player;
    internal float timerbonus;
    internal MiniGamePiece nextPiece;
    internal MiniGamePiece currentPiece;
    [SerializeField]
    internal float gamePieceActiveTime = 1f;
    
    [SerializeField]
    internal Sprite faceFlyerSprite;
    [SerializeField]
    internal Sprite tikTikSprite;
    [SerializeField]
    internal Sprite booglelSprite;
    [SerializeField]
    internal Sprite eweTubeSprite;

    [SerializeField]
    internal float timeLeft = 10f;
   
    internal float timer = 30f;
    [SerializeField]
    internal float defaultTimer = 30f;
    [SerializeField]
    internal float maxTimer = 120f;
    [SerializeField]
    internal float preTimer = 5f;

    [SerializeField]
    internal float faceFlyerBonus = 0f;
    [SerializeField]
    internal float tikTikBonus = 0f;
    [SerializeField]
    internal float boogleBonus = 0f;
    [SerializeField]
    internal float eweTubeBonus = 0f;

    [SerializeField]
    internal float totalBonusChancesHad = 0f;


    [SerializeField]
    internal MiniGamePiece[] gamePieces;
    [SerializeField]
    internal bool runMiniGame = false;
    [SerializeField]
    internal bool timerRunning = false;
    [SerializeField]
    internal bool runTimer = false;


    public void OnEnable()
    {

            timerbonus = Mathf.Round((PrepareForReleasePanel.marketingBudget / 1000f));

        if (timerbonus > 1f && (defaultTimer + timerbonus) < maxTimer)
        {
            timer = defaultTimer + timerbonus;
            timeLeft = timer;
        }
        else
        {
            timer = defaultTimer;
            timeLeft = timer;
        }
 
        StartCoroutine(PreGameWait());
    }

    public void OnDisable()
    {
        runMiniGame = false;
        timer = 0f;
        timerDisplayText.text = "0:00";
        timerbonus = 0f;
        faceFlyerBonus = 0f;
        tikTikBonus = 0f;
        boogleBonus = 0f;
        eweTubeBonus = 0f;
        totalBonusChancesHad = 0f;
        runTimer = false;
        timerRunning = false;
        StopCoroutine(GamePieceActive());
    }


    public void GetRandomGamePiece()
    {
        if (runMiniGame)
        {
            StopCoroutine(GamePieceActive());
            Timer();
            nextPiece = gamePieces[Random.Range(0, gamePieces.Length)];
            nextPiece.gameObject.SetActive(true);
            int index = Random.Range(0, 3);
            totalBonusChancesHad++;
            switch (index)
            {
                case 0:
                    nextPiece.image.sprite = faceFlyerSprite;
                    nextPiece.isFaceNovelPiece = true;
                    break;
                case 1:
                    nextPiece.image.sprite = tikTikSprite;
                    nextPiece.isTikTikPiece = true;
                    break;
                case 2:
                    nextPiece.image.sprite = booglelSprite;
                    nextPiece.isBooglelPiece = true;
                    break;
                case 3:
                    nextPiece.image.sprite = eweTubeSprite;
                    nextPiece.isEweTubePiece = true;
                    break;
            }
            
            StartCoroutine(GamePieceActive());
        }
    }
    public void Timer()
    {
        if (runTimer && timerRunning)
        {
            if (timeLeft >=1)
            {
                timeLeft -- ;
                DisplayTimer(timeLeft);



            }
           if (timeLeft < 1)
            {
                runMiniGame = false;
                timerRunning = false;

                GameFinished();
            }

        }
    }

    public void DisplayTimer(float time)
    {

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timerDisplayText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    
    public void ResetGamePieces()
    {
        foreach (MiniGamePiece piece in gamePieces)
        {
            piece.isFaceNovelPiece = false;
            piece.isTikTikPiece = false;
            piece.isBooglelPiece = false;
            piece.isEweTubePiece = false;
            piece.image.sprite = null;
            piece.thisPiece.SetActive(false);
        }

    }

    

    public void AssignGamePieceInfo()
    {

        nextPiece = gamePieces[Random.Range(0, gamePieces.Length)];



    }

    public void GameFinished()
    {
        StopCoroutine(GamePieceActive());
        PrepareForReleasePanel.faceFlyerMiniGameBonus = faceFlyerBonus;
        PrepareForReleasePanel.tikTikMiniGameBonus = tikTikBonus;
        PrepareForReleasePanel.boogleMiniGameBonus = boogleBonus;
        PrepareForReleasePanel.eweTubeMiniGameBonus = eweTubeBonus;
        PrepareForReleasePanel.totalMiniGameBonusChances = totalBonusChancesHad;
        resultsPanel.SetActive(true);
        //this.gameObject.SetActive(false);




    }

    public IEnumerator GamePieceActive()
    {
        
        yield return new WaitForSeconds(gamePieceActiveTime);
        nextPiece.thisPiece.SetActive(false);
        GetRandomGamePiece();
        //AssignGamePieceInfo();
       
    }

    public IEnumerator PreGameWait()
    {
        yield return new WaitForSeconds(preTimer);
        runMiniGame = true;
        runTimer = true;
        timerRunning = true;
        GetRandomGamePiece();
        StopCoroutine(PreGameWait());

    }

}
