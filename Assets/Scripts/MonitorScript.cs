using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonitorScript : MonoBehaviour
{
    [SerializeField]
    internal TextMeshProUGUI timeText;
    [SerializeField]
    internal TextMeshProUGUI dateText;
    internal string hours;
    internal string minutes;
    internal string day;
    internal string month;
    internal string year;
    internal bool isAm;
    public void Start()
    {
        StartCoroutine(DisplayTime());
    }
    void Update()
    {
        // timeText.text = System.DateTime.UtcNow.ToString("HH:mm MMMM dd, yyyy");
        //SetTime();
    }

    public void SetTime()
    {

        if(System.DateTime.Now.Hour<12)
        {
            hours = System.DateTime.Now.Hour.ToString("00");
            isAm = true;
        }
        else if(System.DateTime.Now.Hour>12)
        {


            hours = (System.DateTime.Now.Hour - 12).ToString("00");
            isAm = false;
        }
        else if (System.DateTime.Now.Hour ==12)
        {
            hours = System.DateTime.Now.Hour.ToString("00");
            isAm = false;

        }
    
        minutes = System.DateTime.Now.Minute.ToString("00");
        day = System.DateTime.Now.Day.ToString("00");
        month = System.DateTime.Now.ToString("MMMM");
        year = System.DateTime.Now.Year.ToString();
        
        if (isAm)
        {
            timeText.text = hours + ":" + minutes + " AM";
        }
        else
        {
            timeText.text = hours + ":" + minutes + " PM";
        }
            dateText.text = month + " " + day + ", " + year;

      



    }

    IEnumerator DisplayTime()
    {
        //SetTime();
        //yield return new WaitForSeconds(60f);
        
        SetTime();
        yield return new WaitForSeconds(60f);

    }
}
    