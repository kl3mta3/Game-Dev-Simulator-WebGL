using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewsFeedPanel : MonoBehaviour
{



    [SerializeField]
    internal ViralTrendsSoObject trends;

    [SerializeField]
    internal NewsFeedPrefab[] possibleNewsFeeds = new NewsFeedPrefab[3];

    internal string[] newsFeedTrendStrings = new string[7];
    //internal string[] newsFeedPreferedStrings = new string[3];
   // internal string[] newsFeedHatedStrings = new string[3];

    public void OnEnable()
    {
        CreateMarketingTrendString();
        DecidedWhatToShow();


    }

    public void DecidedWhatToShow()
    {
        List<string> newsFeedList = new List<string>();

        for (int i = 0; i < newsFeedTrendStrings.Length; i++)
        {
            newsFeedList.Add(newsFeedTrendStrings[i]);

        }

        for (int i = 0; i < possibleNewsFeeds.Length; i++)
        {


            int randomIndex = Random.Range(0, newsFeedList.Count);
            possibleNewsFeeds[i].feedString.text = newsFeedList[randomIndex];
            newsFeedList.RemoveAt(randomIndex);
        }



    }

    public void CreateMarketingTrendString()
    {
        string incomingMarketingTrend = trends.currentViralMarketingTrendName;
        string incomingDemographicTrend = trends.currentViralDemographicTrendName;

        newsFeedTrendStrings[0] = "Market Analists are predicting " + incomingMarketingTrend + " to be a huge hit with the " + incomingDemographicTrend+ " generation.";
        newsFeedTrendStrings[1] =  incomingMarketingTrend + " Makes bank with ads aimed towards the " + incomingDemographicTrend + " Demographic.";
        newsFeedTrendStrings[2] = "The " + incomingDemographicTrend + " Demographic has spoken." + incomingMarketingTrend +" popularity on the rise.";
        newsFeedTrendStrings[3] = "You can go wrong marketing with " + incomingMarketingTrend +" experts say.";
        newsFeedTrendStrings[4] = "Research suggests success in the " + incomingDemographicTrend + " sector.";
        newsFeedTrendStrings[5] = "Boom to Industry suggests profits all Around.";
        newsFeedTrendStrings[6] = "All Demographics slow on spending.";
    }


}
