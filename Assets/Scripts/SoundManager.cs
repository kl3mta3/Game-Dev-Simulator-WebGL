using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    internal AudioSource backgroundTrackAudio;
    
    [SerializeField]
    internal AudioSource buttonPressAudio1;
    [SerializeField]
    internal AudioSource buttonPressAudio2;
    [SerializeField]
    internal AudioSource buttonPressAudio3;
    
    [SerializeField]
    internal AudioSource gamebuildingDayAudio;
    [SerializeField]
    internal AudioSource gamebuildingNightAudio;
    
    [SerializeField]
    internal AudioSource addMoney;
    [SerializeField]
    internal AudioSource loseMoney;
    
    [SerializeField]
    internal AudioSource ticToc;

    [SerializeField]
    internal AudioSource hireSomeone;
    [SerializeField]
    internal AudioSource buyAnAsset;

    [SerializeField]
    internal AudioSource gameBuilt;

    [SerializeField]
    internal AudioSource statAdjust;

    [SerializeField]
    internal bool playBackgroundTrack;
    internal bool muteMusic;
    
    public void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SoundManager");

        if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);
        


        if (playBackgroundTrack)
        {
            backgroundTrackAudio.Play();
        }
    }
    public void PlaySound(AudioSource sound)
    {
        sound.Play();
    }

    public void StopSound(AudioSource sound)
    {
        sound.Stop();
    }


    public void MuteMusic()
    {


        muteMusic = !muteMusic;
        if (muteMusic)
        {
            backgroundTrackAudio.Pause();
        }
        else
        {
            backgroundTrackAudio.Play();
        }

        
    }
    
    public void PlayButton1Sound()
    {

        PlaySound(buttonPressAudio1);
    }
    public void PlayButton2Sound()
    {

        PlaySound(buttonPressAudio2);
    }
    public void PlayButton3Sound()
    {

        PlaySound(buttonPressAudio3);
    }

    public void PlayStatAdjustSound()
    {

        PlaySound(statAdjust);
    }


    public void BuyAsset()
    {
        StartCoroutine(PlayBuySounds());
    }

    IEnumerator PlayBuySounds()
    {
       
        PlaySound(loseMoney);
        yield return new WaitForSeconds(loseMoney.clip.length);
        PlaySound(buyAnAsset);
        StopCoroutine(PlayBuySounds());
    }

    public void HireSomeone()
    {
        StartCoroutine(PlayHireSounds());
    }

    IEnumerator PlayHireSounds()
    {

        PlaySound(loseMoney);
        yield return new WaitForSeconds(loseMoney.clip.length);
        PlaySound(hireSomeone);
        StopCoroutine(PlayHireSounds());
    }

}

