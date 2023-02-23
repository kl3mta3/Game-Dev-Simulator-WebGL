using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarGraph : MonoBehaviour
{

    [SerializeField]
    internal float[] values;
    [SerializeField]
    internal Image[] barGraphImages;

    internal float totalValueOfFloats;
    public void Start()
    {
        SetValues(values);
    }

    public void SetValues(float[] valuesToSet)
    {
        
        totalValueOfFloats = 0f;
        for (int i = 0; i < values.Length; i++)
        {
            totalValueOfFloats += values[i];
        }

        for (int i = 0; i < barGraphImages.Length; i++)
        {
            
            barGraphImages[i].fillAmount = values[i]/totalValueOfFloats;
        }

    }


}
