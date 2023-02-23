using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "New Prospects Database", menuName = "Database/Prospects")]
    public class FreeLanceDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public FreeLanceProspect[] Prospects;

    [ContextMenu("Update ID's")]
    public void UpdateID()
    {
        for (int i = 0; i < Prospects.Length; i++)
        {
            if (Prospects[i].prospectId != i)
            {
                Prospects[i].prospectId = i;
            }
        }

    }
    public void OnAfterDeserialize()
    {
        UpdateID();
    }

    public void OnBeforeSerialize()
    {
    }



    public FreeLanceProspect GetRandomFreeLanceProspect()
    {

        return Prospects[Random.Range(0, Prospects.Length)];
    }


}

