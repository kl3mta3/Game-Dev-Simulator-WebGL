using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;

public class CharacterCreation : MonoBehaviour
{
    [SerializeField]
    internal CharacterSoObject characterSO;

    [SerializeField]
    internal SoundManager soundManager;
    [SerializeField]
    internal GameObject soundManagerPrefab;

    [SerializeField]
    internal GameObject menuPanelPopup;

    [SerializeField]
    internal float maxAvailableSkillPoints;
    [SerializeField]
    internal float availableSkillPoints;
    [SerializeField]
    internal float usedSkillPoints;

    [SerializeField]
    internal float startingCash;

    [SerializeField]
    internal float startingTaxRate;

    [SerializeField]
    internal Slider modelingSlider;
    [SerializeField]
    internal Slider codingSlider;
    [SerializeField]
    internal Slider designSlider;
    [SerializeField]
    internal Slider marketingSlider;


    [SerializeField]
    internal Toggle _unity;
    [SerializeField]
    internal Toggle _unreal;
    [SerializeField]
    internal Toggle _ownEngine;


    [SerializeField]
    internal GameObject usingUnrealPanel;
    [SerializeField]
    internal GameObject usingOwnEnginePanel;

    [SerializeField]
    internal TextMeshProUGUI playerNameText;
    [SerializeField]
    internal TextMeshProUGUI modelingValueText;
    [SerializeField]
    internal TextMeshProUGUI codingValueText;
    [SerializeField]
    internal TextMeshProUGUI designValueText;
    [SerializeField]
    internal TextMeshProUGUI marketingValueText;
    [SerializeField]
    internal TextMeshProUGUI availableSkillPointsText;

    [SerializeField]
    internal TMP_InputField playerNameInput;

    private TouchScreenKeyboard keyboard;
    private bool keyboardActive = false;


    public void OnEnable()
    {
        if (soundManager == null)
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
        // UpdateUsedSkillPoints();
        usedSkillPoints = modelingSlider.value + codingSlider.value + designSlider.value + marketingSlider.value;
        availableSkillPoints = maxAvailableSkillPoints - usedSkillPoints;
    }
    public void Update()
    {
        //usedSkillPoints = modelingSlider.value + codingSlider.value + designSlider.value + marketingSlider.value;
        //availableSkillPoints = maxAvailableSkillPoints - usedSkillPoints;
        //UpdateUsedSkillPoints();
        //UpdateSliderMaxValue();
        UpdateDisplay();
        
        if(keyboardActive)
        {
           
            OnChangeOSK();



        }

    }

    public void UpdateDisplay()
    {
        //usedSkillPoints = modelingSlider.value + codingSlider.value + designSlider.value + marketingSlider.value;
        //availableSkillPoints = maxAvailableSkillPoints - usedSkillPoints;

        modelingValueText.text = Mathf.Round(modelingSlider.value).ToString();
        codingValueText.text = Mathf.Round(codingSlider.value).ToString();
        designValueText.text = Mathf.Round(designSlider.value).ToString();
        marketingValueText.text = Mathf.Round(marketingSlider.value).ToString();

        availableSkillPointsText.text = Mathf.Round(availableSkillPoints).ToString();
    }

    public void UpdateUsedSkillPoints()
    {
        //usedSkillPoints = modelingSlider.value + codingSlider.value + designSlider.value + marketingSlider.value;
        //availableSkillPoints = maxAvailableSkillPoints - usedSkillPoints;
        
        //modelingSlider.maxValue = availableSkillPoints+ modelingSlider.value;
        //codingSlider.maxValue = availableSkillPoints +codingSlider.value;
        //designSlider.maxValue = availableSkillPoints + designSlider.value;
        //marketingSlider.maxValue = availableSkillPoints + marketingSlider.value;
        //UpdateDisplay();
        //soundManager.PlayButton3Sound();

    }
    public void UpdateModelingSkillSlider()
    {
        usedSkillPoints = modelingSlider.value + codingSlider.value + designSlider.value + marketingSlider.value;
        availableSkillPoints = maxAvailableSkillPoints - usedSkillPoints;
        float max= availableSkillPoints + modelingSlider.value;
        modelingSlider.maxValue = max;
        //UpdateDisplay();
        soundManager.PlayButton3Sound();
    }
    public void UpdateMarketingSkillSlider()
    {
        usedSkillPoints = modelingSlider.value + codingSlider.value + designSlider.value + marketingSlider.value;
         availableSkillPoints = maxAvailableSkillPoints - usedSkillPoints;
        float max = availableSkillPoints + (marketingSlider.value);
        marketingSlider.maxValue = max;

       // UpdateDisplay();
        soundManager.PlayButton3Sound();

    }
    public void UpdateCodingSkillSlider()
    {
        usedSkillPoints = modelingSlider.value + codingSlider.value + designSlider.value + marketingSlider.value;
         availableSkillPoints = maxAvailableSkillPoints - usedSkillPoints;
       float max = availableSkillPoints + codingSlider.value;
        codingSlider.maxValue = max;
       // UpdateDisplay();
        soundManager.PlayButton3Sound();
    }
    public void UpdateDesignSkillSlider()
    {
         usedSkillPoints = modelingSlider.value + codingSlider.value + designSlider.value + marketingSlider.value;
        availableSkillPoints = maxAvailableSkillPoints - usedSkillPoints;
        float max = availableSkillPoints + designSlider.value;
        designSlider.maxValue = max;
       // UpdateDisplay();
        soundManager.PlayButton3Sound();
    }

    public void MuteMusic()
    {


        soundManager.MuteMusic();
    }
    public void ToggleOwnEngine()
    {

        _unity.isOn = false;
        _unreal.isOn = false;
        soundManager.PlayButton2Sound();


    }
    public void ToggleUnity()
    {

        _unreal.isOn = false;
        _ownEngine.isOn = false;
        soundManager.PlayButton2Sound();

    }
    public void ToggleUnreal()
    {

        _unity.isOn = false;
        _ownEngine.isOn = false;
        soundManager.PlayButton2Sound();
    }

    public void ModelingUp()
    {
            modelingSlider.value++;
        
        UpdateModelingSkillSlider();
    }


    public void CodingUp()
    {
        codingSlider.value++;
        
        UpdateCodingSkillSlider();
    }

    public void DesignUp()
    {
            designSlider.value++;
        
        UpdateDesignSkillSlider();
    }
    public void MarketingUp()
    {
            marketingSlider.value++;
        
        UpdateMarketingSkillSlider();
    }

    public void ModelingDown()
    {
            modelingSlider.value--;
       
        UpdateModelingSkillSlider();
    }


    public void CodingDown()
    {
       
            codingSlider.value--;
        
        UpdateCodingSkillSlider();

    }

    public void DesignDown()
    {
        
            modelingSlider.value--;
       
        UpdateDesignSkillSlider();

    }
    public void MarketingDown()
    {
        
            marketingSlider.value--;
       
        UpdateMarketingSkillSlider();

    }

    public void OpenOSK()
    {
        if(Application.isMobilePlatform)
        {
            keyboard = TouchScreenKeyboard.Open(playerNameInput.text, TouchScreenKeyboardType.Default, false, false, false, false, "Enter your name");
            keyboardActive = true;
        }
    }

    public void OnChangeOSK()
    {

        playerNameInput.text = keyboard.text;



    }
    public void CloseOSK()
    {
        if (Application.isMobilePlatform)
        {
            //keyboard = TouchScreenKeyboard.Open(playerNameInput.text, TouchScreenKeyboardType.Default, false, false, false, false, "Enter your name");

            keyboardActive = false;
        }
    }

    public void CreateChraceter()
    {

        if (_unity.isOn)
        {
            characterSO.modelingSKill = modelingSlider.value;
            characterSO.codongSKill = codingSlider.value;
            characterSO.designSKill = designSlider.value;
            characterSO.marketingSKill = marketingSlider.value;
            characterSO.isUnity = _unity.isOn;
            characterSO.isUnreal = _unreal.isOn;
            characterSO.isOwnEngine = _ownEngine.isOn;
            characterSO.cash = startingCash;
            characterSO.playerName = playerNameInput.text;
            characterSO.soundManager = soundManager;
            characterSO.playerTaxRate = startingTaxRate;
            soundManager.PlayButton1Sound();
            StartCoroutine(LoadGameScene());
            Debug.Log("Character Created");
        }
        else if (_unreal.isOn)
        {
            usingUnrealPanel.SetActive(true);
        }
        else if (_ownEngine.isOn)
        {
            usingOwnEnginePanel.SetActive(true);
        }

    }

    public void OpenMenuPanel()
    {
        menuPanelPopup.SetActive(true);
        soundManager.PlayButton1Sound();
    }
    public void CloseMenuPanel()
    {
        menuPanelPopup.SetActive(false);
        soundManager.PlayButton2Sound();
       
    }

    public void LoadMainMenu()
    {
        soundManager.PlayButton2Sound();
        StartCoroutine(LoadMenuScene());
    }
    IEnumerator LoadGameScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameScene");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadMenuScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
