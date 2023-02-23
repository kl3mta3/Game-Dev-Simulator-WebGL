using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PieChart : MonoBehaviour
{
    [SerializeField]
    internal float[] values;
    [SerializeField]
    internal Image[] pieChartImages;

    public void Start()
    {
        SetValues(values);
    }

    public void SetValues(float[] valuesToSet)
    {
        float totalValues = 0f;
        for (int i = 0; i < pieChartImages.Length; i++)
        {
            totalValues += FindPercentage(valuesToSet, i);
            pieChartImages[i].fillAmount = totalValues;
        }

    }

    private float FindPercentage(float[] valueToSet, int index)
    {
        float totalAmount = 0;

        for (int i = 0; i < valueToSet.Length; i++)
        {

            totalAmount += valueToSet[i];
        }

        return valueToSet[index] / totalAmount;

    }
}
