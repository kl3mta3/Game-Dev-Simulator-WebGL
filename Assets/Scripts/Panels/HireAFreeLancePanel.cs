using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireAFreeLancePanel : MonoBehaviour
{
    [SerializeField]
    internal FreeLanceDatabaseObject prospects;
    //[SerializeField]
    //internal Player player;

    [SerializeField]
    internal ProspectPanel[] prospectPanelPrefabs;


    public void OnEnable()
    {
        SetPanels();
    }
        
    public void SetPanels()
    {
        foreach (ProspectPanel prospectPanel in prospectPanelPrefabs)
        {
            FreeLanceProspect prospect = prospects.GetRandomFreeLanceProspect();
            prospectPanel.prospect = prospect;
            prospectPanel.SetPanel(prospect);

        }
    }
    

}
