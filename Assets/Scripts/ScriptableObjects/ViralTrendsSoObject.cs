using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "ViralTrendsSO", menuName = "ViralTrendsSO")]
public class ViralTrendsSoObject : ScriptableObject
{
    [Header("Marketing Trends")]
    
    [SerializeField]
    internal string currentViralMarketingTrendName;
    [SerializeField]
    internal float currentViralMarketingTrendIndex;

    internal Dictionary<string, float> marketingTrends = new Dictionary<string, float>();
    internal string[] marketingTrendsNames = new string[4] {"FaceFlyer", "TikTik", "Boogle", "EweTube" };
    internal float[] marketingTrendsIndex = new float[4] { 1, 2, 3, 4 };


    [Header("Demographic Trends")]
    
    [SerializeField]
    internal string currentViralDemographicTrendName;
    [SerializeField]
    internal float currentViralDemographicTrendIndex;
    
    internal Dictionary<string, float> demographicTrends = new Dictionary<string, float>();
    internal string[] demographicTrendsNames = new string[5] { "Kids", "Teens", "College", "Adults","Boomer" };
    internal float[] demographicTrendsIndex = new float[5] { 1, 2, 3, 4,5 };

    [Header("Platform Trends")]
    
    [SerializeField]
    internal string currentViralPlatformTrendName;
    [SerializeField]
    internal float currentViralPlatformTrendIndex;
    
    internal Dictionary<string, float> platformTrends = new Dictionary<string, float>();
    internal string[] platformTrendsNames = new string[6] { "Steem", "Epik", "Pear", "Cyborg", "PlayBox", "XStation" };
    internal float[] platformTrendsIndex = new float[6] { 1, 2, 3, 4, 5,6 };


    [Header("General Trends")]

    [SerializeField]
    internal bool circlesPrefered;
    [SerializeField]
    internal bool squaresPrefered;
    [SerializeField]
    internal bool triangelsPrefered;
    [SerializeField]
    internal bool beepsPrefered;
    [SerializeField]
    internal bool dingsPrefered;
    [SerializeField]
    internal bool LightsPrefered;

    [SerializeField]
    internal bool circlesHated;
    [SerializeField]
    internal bool squaresHated;
    [SerializeField]
    internal bool triangelsHated;
    [SerializeField]
    internal bool beepsHated;
    [SerializeField]
    internal bool dingsHated;
    [SerializeField]
    internal bool LightsHated;


    


    //[Header("Genre Trends")]
    //to Be Added



    public void RandomizeViralTrends()
    {
        ResetTrends();
        for (int i = 0; i < marketingTrendsNames.Length; i++)
        {
            marketingTrends.Add(marketingTrendsNames[i], marketingTrendsIndex[i]);
        }

        for (int i = 0; i < demographicTrendsNames.Length; i++)
        {
            demographicTrends.Add(demographicTrendsNames[i], demographicTrendsIndex[i]);
        }

        for (int i = 0; i < platformTrendsNames.Length; i++)
        {
            platformTrends.Add(platformTrendsNames[i], platformTrendsIndex[i]);
        }

       // Debug.Log("marketingTrends.Count = " + marketingTrends.Count);
       // Debug.Log("demographicTrends.Count = " + demographicTrends.Count);
        //Debug.Log("platformTrends.Count = " + platformTrends.Count);




        float marketingIndex = Random.Range(1, marketingTrends.Count);
       // Debug.Log("marketingIndex = " + marketingIndex);
        foreach (KeyValuePair<string,float> marketingTrend in marketingTrends)
        {
            if (marketingTrend.Value == marketingIndex)
            {
                currentViralMarketingTrendIndex = marketingIndex;
                currentViralMarketingTrendName = marketingTrend.Key;
                break;
            }
        }


        float demographicIndex = Random.Range(1, demographicTrends.Count);
       // Debug.Log("demographicIndex = " + demographicIndex);
        foreach (KeyValuePair<string, float> demographicTrend in demographicTrends)
        {
            if (demographicTrend.Value == demographicIndex)
            {
                currentViralDemographicTrendIndex = demographicIndex;
                currentViralDemographicTrendName = demographicTrend.Key;
                break;
            }
        }


        float platformIndex = Random.Range(1, platformTrends.Count);
        //Debug.Log("platformIndex = " + platformIndex);
        foreach (KeyValuePair<string, float> platformTrend in platformTrends)
        {
            if (platformTrend.Value == platformIndex)
            {
                currentViralPlatformTrendIndex = platformIndex;
                currentViralPlatformTrendName = platformTrend.Key;
                break;
            }
        }


        float preferedIndex = 0;
        if (preferedIndex < 2)
        {
            circlesPrefered = Random.Range(0, 2) == 0;
            if(circlesPrefered)
            {
                preferedIndex++;
            }
        }
        if (preferedIndex < 2)
        {
           
            squaresPrefered = Random.Range(0, 2) == 0;
            if (squaresPrefered)
            {
                preferedIndex++;
            }
        }
        if (preferedIndex < 2)
        {

            
             triangelsPrefered = Random.Range(0, 2) == 0;
            if (triangelsPrefered)
            {
                preferedIndex++;
            }
        }
        if (preferedIndex < 2)
        {

        beepsPrefered = Random.Range(0, 2) == 0;
            
            if (beepsPrefered)
            {
                preferedIndex++;
            }
        }
        if (preferedIndex < 2)
        {

           
            dingsPrefered = Random.Range(0, 2) == 0;
            if (dingsPrefered)
            {
                preferedIndex++;
            }
        }
        if (preferedIndex < 2)
        {

            
        LightsPrefered = Random.Range(0, 2) == 0;
            if (LightsPrefered)
            {
                preferedIndex++;
            }
        }


        float hatedIndex = 0;


        if (hatedIndex < 2)
        {
            circlesHated = Random.Range(0, 2) == 0; 
            if (circlesHated)
            {
                hatedIndex++;
            }
        }
        if (hatedIndex < 2)
        {
           
            squaresHated = Random.Range(0, 2) == 0;
            if (squaresHated)
            {
                hatedIndex++;
            }
        }
        if (hatedIndex < 2)
        {
            
            triangelsHated = Random.Range(0, 2) == 0;
            if (triangelsHated)
            {
                hatedIndex++;
            }
        }
        if (hatedIndex < 2)
        {
             beepsHated = Random.Range(0, 2) == 0;
            if (beepsHated)
            {
                hatedIndex++;
            }
        }
        if (hatedIndex < 2)
        {
            dingsHated = Random.Range(0, 2) == 0;
            if (dingsHated)
            {
                hatedIndex++;
            }
        }
        if (hatedIndex < 2)
        {
             LightsHated = Random.Range(0, 2) == 0;
            if (LightsHated)
            {
                hatedIndex++;
            }
        }


    }

    public void ResetTrends()
    {

        circlesPrefered = false;
        squaresPrefered = false;
        triangelsPrefered = false;
        beepsPrefered = false;
        dingsPrefered = false;
        LightsPrefered = false;

        circlesHated = false;
        squaresHated = false;
        triangelsHated = false;
        beepsHated = false;
        dingsHated = false;
        LightsHated = false;

        currentViralMarketingTrendIndex = 0;
        currentViralMarketingTrendName = "";

        currentViralDemographicTrendIndex = 0;
        currentViralDemographicTrendName = "";

        currentViralPlatformTrendIndex = 0;
        currentViralPlatformTrendName = "";



    }



public void OnApplicationQuit()
    {
        ResetTrends();
    }
}

