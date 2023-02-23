using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] 
    internal  GameInfoSoObject gameInfoSoObject;


    [SerializeField]
    internal SoundManager soundManager;

    [SerializeField]
    internal GameObject soundManagerPrefab;


    [SerializeField]
    internal GameObject startText;

    [SerializeField]
    internal GameObject mainPanel;

    internal bool mainPanelOpen = false;
   


    public void OnEnable()
    {
        Debug.Log("MainMenu OnEnable");
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        //SoundManagerCheck();


    }
        
    public void SoundManagerCheck()
    {


        Debug.Log("Sound Manager CHeck");
        if (soundManager == null )

        {
            Debug.Log("soundManager == null");
            if (GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>())
            {
                Debug.Log("GameObject.FindGameObjectWithTag(SoundManager).GetComponent<SoundManager>()");
                soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
                Debug.Log("soundManager = " + soundManager);
            }
            else
            {
                Debug.Log("SoundManager not found");
                soundManager = Instantiate(soundManagerPrefab).GetComponent<SoundManager>();
            }
        }


    }

    public void Update()
    {
     
        if (Input.anyKeyDown && !mainPanelOpen)
        {
            startText.SetActive(false);
            mainPanel.SetActive(true);
            mainPanelOpen = true;
            soundManager.PlayButton2Sound();
        }
        
    }


    public void NewGame()
    {
        gameInfoSoObject.isNewGame = true;
        gameInfoSoObject.isContinuedGame = false;
        StartCoroutine(LoadCharacterCreation());
        soundManager.PlayButton1Sound();
    }

    public void LoadGame()
    {
        if (ES3.KeyExists("playerData"))
        {
            gameInfoSoObject.isNewGame = false;
            gameInfoSoObject.isContinuedGame = true;
            StartCoroutine(LoadGameScene());
            soundManager.PlayButton1Sound();
        }
    }

    public void QuitGame()
    {
        soundManager.PlayButton1Sound();
        Application.Quit();
    }


    IEnumerator LoadCharacterCreation()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("CharacterCreationScene");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    IEnumerator LoadGameScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameScene");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
