using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class PresentsScreenScript : MonoBehaviour
{

    [SerializeField]
    private GameObject imagescreen;


    public RawImage image;
  
    public List<VideoClip> videoClipList;

    private List<VideoPlayer> videoPlayerList;
    private int videoIndex = 0;
    [SerializeField]
    private float waitTime = 5;



    private void Start()
    {
        StartCoroutine(playVideo());
    }
    
    IEnumerator playVideo(bool firstRun = true)
    {
        if (videoClipList == null || videoClipList.Count <= 0)
        {
            Debug.LogError("No video clips found");
            yield break;
        }

        //Init videoPlayerList first time this function is called
        if (firstRun)
        {

            videoPlayerList = new List<VideoPlayer>();
            for (int i = 0; i < videoClipList.Count; i++)
            {
                //Create new Object to hold the Video and the sound then make it a child of this object
                GameObject vidHolder = new GameObject("VP" + i);
                vidHolder.transform.SetParent(transform);

                //Add VideoPlayer to the GameObject
                VideoPlayer videoPlayer = vidHolder.AddComponent<VideoPlayer>();
                videoPlayerList.Add(videoPlayer);

                //Add AudioSource to  the GameObject
                AudioSource audioSource = vidHolder.AddComponent<AudioSource>();

                //Disable Play on Awake for both Video and Audio
                videoPlayer.playOnAwake = false;
                audioSource.playOnAwake = false;

                //We want to play from video clip not from url
                videoPlayer.source = VideoSource.VideoClip;

                //Set Audio Output to AudioSource
                videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

                //Assign the Audio from Video to AudioSource to be played
                videoPlayer.EnableAudioTrack(0, true);
                videoPlayer.SetTargetAudioSource(0, audioSource);

                //Set video Clip To Play 
                videoPlayer.clip = videoClipList[i];
            }
        }

        //Make sure that the NEXT VideoPlayer index is valid
        if (videoIndex >= videoPlayerList.Count)
            yield break;

        //Prepare video
        videoPlayerList[videoIndex].Prepare();

        //Wait until this video is prepared
        while (!videoPlayerList[videoIndex].isPrepared)
        {
            //Debug.Log("Preparing Index: " + videoIndex);
            yield return null;
        }
        //Debug.LogWarning("Done Preparing current Video Index: " + videoIndex);

        //Assign the Texture from Video to RawImage to be displayed
        image.texture = videoPlayerList[videoIndex].texture;

        //Play first video
        videoPlayerList[videoIndex].Play();
      
        imagescreen.SetActive(true);

        //Wait while the current video is playing
        bool reachedHalfWay = false;
        int nextIndex = (videoIndex + 1);
        while (videoPlayerList[videoIndex].isPlaying)
        {
            

            //(Check if we have reached half way)
            if (!reachedHalfWay && videoPlayerList[videoIndex].time >= (videoPlayerList[videoIndex].clip.length / 2))
            {
                reachedHalfWay = true; //Set to true so that we don't evaluate this again

                //Make sure that the NEXT VideoPlayer index is valid. Othereise Exit since this is the end
                if (nextIndex >= videoPlayerList.Count)
                {
                    
                    StartCoroutine(LoadAsyncSceneOneAfterVideo());
                    yield break;
                }

                //Prepare the NEXT video
                
                videoPlayerList[nextIndex].Prepare();
            }
            yield return null;
        }
        

        //Wait until NEXT video is prepared
        while (!videoPlayerList[nextIndex].isPrepared)
        {
            
            yield return null;
        }

        

        //Increment Video index
        videoIndex++;

        //Play next prepared video. Pass false to it so that some codes are not executed at-all
        StartCoroutine(playVideo(false));
    }


    IEnumerator LoadAsyncSceneOneAfterVideo()
    {
        yield return new WaitForSeconds(waitTime);
        //transition.SetTrigger("Start");
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");


        while (!asyncLoad.isDone)
        {

            yield return null;
        }

    }
}

