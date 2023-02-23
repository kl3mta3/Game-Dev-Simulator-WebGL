using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    [SerializeField]
    internal CharacterSoObject characterSo;
    [SerializeField]
    internal GameInfoSoObject gameInfoSoObject;
    [SerializeField]
    internal GameObject menuPanel;

    [SerializeField]
    internal ViralTrendsSoObject viralTrendSo;
    
    [SerializeField]
    internal float viralTrendRestTime;

    [SerializeField]
    internal float baseGamePayout;

    [SerializeField]
    internal float viralPayoutMultiplier;

    [SerializeField]
    internal Player player;

    [SerializeField]
    internal SoundManager soundManager;

    [SerializeField]
    internal GameObject soundManagerPrefab;


    [SerializeField]
    internal TextMeshProUGUI playerNameText;

    [SerializeField]
    internal TextMeshProUGUI modelingCurrentValueText;
    [SerializeField]
    internal TextMeshProUGUI codingCurrentValueText;
    [SerializeField]
    internal TextMeshProUGUI designCurrentValueText;
    [SerializeField]
    internal TextMeshProUGUI marketingCurrentValueText;

    [SerializeField]
    internal TextMeshProUGUI modelingBonusValueText;
    [SerializeField]
    internal TextMeshProUGUI codingBonusValueText;
    [SerializeField]
    internal TextMeshProUGUI designBonusValueText;
    [SerializeField]
    internal TextMeshProUGUI marketingBonusValueText;

    [SerializeField]
    internal Color positiveColor;

    [SerializeField]
    internal Color negativeColor;

    
    [SerializeField]
    internal TextMeshProUGUI currentCashText;

    [SerializeField]
    internal TextMeshProUGUI currentProjectCostText;

    [SerializeField]
    internal NewsFeedPanel newsFeedPanel;
    

    [SerializeField]
    internal HireAFreeLancePanel freeLancePanel;
 

    [SerializeField]
    internal float taxRate;

    [SerializeField]
    internal float steemCost;
    [SerializeField]
    internal float epikCost;
    [SerializeField]
    internal float pearCost;
    [SerializeField]
    internal float cyborgCost;
    [SerializeField]
    internal float playBoxCost;
    [SerializeField]
    internal float xStationCost;

    [SerializeField]
    internal float steembaseUnits;
    [SerializeField]
    internal float epikbaseUnits;
    [SerializeField]
    internal float pearbaseUnits;
    [SerializeField]
    internal float cyborgbaseUnits;
    [SerializeField]
    internal float playBoxbaseUnits;
    [SerializeField]
    internal float xStationbaseUnits;

    [SerializeField]
    internal float steemPlatformCut;
    [SerializeField]
    internal float epikPlatformCut;
    [SerializeField]
    internal float pearPlatformCut;
    [SerializeField]
    internal float cyborgPlatformCut;
    [SerializeField]
    internal float playBoxPlatformCut;
    [SerializeField]
    internal float xStationPlatformCut;


    void Start()
    {
        if (gameInfoSoObject.isNewGame && !gameInfoSoObject.isContinuedGame)
        {
            player.modelingSkill = characterSo.modelingSKill;
            player.codingSkill = characterSo.codongSKill;
            player.designSkill = characterSo.designSKill;
            player.marketingSkill = characterSo.marketingSKill;
            player.cash = characterSo.cash;
            player.playerName = characterSo.playerName;
            player.soundManager = characterSo.soundManager;
            player.playerTaxRate = characterSo.playerTaxRate;
            player.currentGameCost = 0;
            modelingCurrentValueText.text = player.modelingSkill.ToString();
            codingCurrentValueText.text = player.codingSkill.ToString();
            designCurrentValueText.text = player.designSkill.ToString();
            marketingCurrentValueText.text = player.marketingSkill.ToString();
            currentCashText.text = "$" + player.cash.ToString();
            playerNameText.text = player.playerName;
            
            if (player.soundManager == null)
            {
                if (GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>())
                {
                    soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
                    player.soundManager = soundManager;
                }
                else
                {
                    Debug.Log("SoundManager not found");
                    soundManager = Instantiate(soundManagerPrefab).GetComponent<SoundManager>();
                    player.soundManager = soundManager;

                }
            }
            else
            {

                soundManager = player.soundManager;
            }

            viralTrendSo.RandomizeViralTrends();
        }
        else if(!gameInfoSoObject.isNewGame && gameInfoSoObject.isContinuedGame)
        {
            LoadGame();
            modelingCurrentValueText.text = player.modelingSkill.ToString();
            codingCurrentValueText.text = player.codingSkill.ToString();
            designCurrentValueText.text = player.designSkill.ToString();
            marketingCurrentValueText.text = player.marketingSkill.ToString();
            currentCashText.text = "$" + player.cash.ToString();
            playerNameText.text = player.playerName;

            if (player.soundManager == null)
            {
                if (GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>())
                {
                    soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();

                }
                else
                {
                    Debug.Log("SoundManager not found");
                    soundManager = Instantiate(soundManagerPrefab).GetComponent<SoundManager>();

                }
            }
            else
            {

                soundManager = player.soundManager;
            }

            viralTrendSo.RandomizeViralTrends();

        }


    }

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SaveGame();
        //}
        UpdateUIStats();
        currentCashText.text = "$" + player.cash.ToString();
    }

    public  void OpenNewsFeed()
    {
    
            newsFeedPanel.gameObject.SetActive(true);
        
        
    }
    public void UpdateUIStats()
    {

        modelingCurrentValueText.text = Mathf.Round(player.modelingSkill+player.modelingSkillBoost).ToString();
        codingCurrentValueText.text = Mathf.Round(player.codingSkill+player.codingSkillBoost).ToString();
        designCurrentValueText.text = Mathf.Round(player.designSkill+player.designSkillBoost).ToString();
        marketingCurrentValueText.text = Mathf.Round(player.marketingSkill+player.marketingSkillBoost).ToString();
        
        currentCashText.text = player.cash.ToString();
        currentProjectCostText.color = new Color(negativeColor.r, negativeColor.g, negativeColor.b, 1);
        currentProjectCostText.text = "$-"+player.currentGameCost.ToString();
        
        if (player.modelingSkillBoost > 0)
        {
            //modelingBonusValueText.color = positiveColor;
            modelingBonusValueText.color = new Color(positiveColor.r, positiveColor.g, positiveColor.b, 1);
            modelingBonusValueText.text = "+" + player.modelingSkillBoost.ToString();
        }
        else if (player.modelingSkillBoost < 0)
        {
            modelingBonusValueText.color = new Color(negativeColor.r, negativeColor.g, negativeColor.b, 1);
            modelingBonusValueText.text =  player.modelingSkillBoost.ToString();


        }
        else if (player.modelingSkillBoost==0)
        {
            modelingBonusValueText.text = "";
        }

        if (player.codingSkillBoost > 0)
        {   
            codingBonusValueText.color = new Color(positiveColor.r, positiveColor.g, positiveColor.b, 1);
            codingBonusValueText.text = "+" + player.codingSkillBoost.ToString();
        }
        else if (player.codingSkillBoost < 0)
        {
            codingBonusValueText.color = new Color(negativeColor.r, negativeColor.g, negativeColor.b, 1);
            codingBonusValueText.text =  player.codingSkillBoost.ToString();


        }
        else if (player.codingSkillBoost == 0)
        {
            codingBonusValueText.text = "";
        }


        if (player.designSkillBoost > 0)
        {
            designBonusValueText.color = new Color(positiveColor.r, positiveColor.g, positiveColor.b, 1);
            designBonusValueText.text = "+" + player.designSkillBoost.ToString();
        }
        else if (player.designSkillBoost < 0)
        {
            designBonusValueText.color = new Color(negativeColor.r, negativeColor.g, negativeColor.b, 1);
            designBonusValueText.text =  player.designSkillBoost.ToString();


        }
        else if (player.modelingSkillBoost == 0)
        {
            designBonusValueText.text = "";
        }

        if (player.marketingSkillBoost > 0)
        {
            marketingBonusValueText.color = new Color(positiveColor.r, positiveColor.g, positiveColor.b, 1);
            marketingBonusValueText.text = "+" + player.marketingSkillBoost.ToString();
        }
        else if (player.designSkillBoost < 0)
        {
            marketingBonusValueText.color = new Color(negativeColor.r, negativeColor.g, negativeColor.b, 1);
            marketingBonusValueText.text =  player.marketingSkillBoost.ToString();


        }
        else if (player.marketingSkillBoost == 0)
        {
            marketingBonusValueText.text = "";
        }



    }
    public void SaveGame()
    {
        ES3.Save("playerData", player);
        ES3.Save("CharacterSoData", characterSo);
        Debug.Log("Game Saved");

    }
    public void MuteMusic()
    {
        soundManager.MuteMusic();
    }
    
    public void LoadGame()
    {
        Player _player= ES3.Load<Player>("playerData");
        player = _player;
        CharacterSoObject _characterSo = ES3.Load<CharacterSoObject>("CharacterSoData");
        characterSo = _characterSo;
        Debug.Log("Game Loaded");

    }
    public void PlayButtonSound()
    {
    
            
        player.soundManager.PlayButton3Sound();
        


    }
    public void OpenMenuPanel()
    {
        player.soundManager.PlayButton1Sound();
        menuPanel.SetActive(true);
    }

    public void CloseMenuPanel()
    {
        player.soundManager.PlayButton1Sound();
        menuPanel.SetActive(false);

    }
    
    public void LoadMainMenu()
    {
        StartCoroutine(LoadMenuScene());



    }

    public IEnumerator RandomizeTrendsTimer()
    {

        yield return new WaitForSeconds(viralTrendRestTime);
        viralTrendSo.RandomizeViralTrends();
    }

    IEnumerator LoadMenuScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    public void OnApplicationQuit()
    {
        SaveGame();
    }
    
}

