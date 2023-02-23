using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAGamePanel : MonoBehaviour
{
   
    [SerializeField]
    internal GameConceptDatabaseObject concepts;

    [SerializeField]
    internal GameConceptPanel[] conceptPanelPrefabs;

    [SerializeField]
    internal Player player;
    public void OnEnable()
    {

        SetPanels();

    }

    public void SetPanels()
    {
       
        foreach (GameConceptPanel gameConceptPanel in conceptPanelPrefabs)
        {
            GameConcept concept = concepts.GetRandomGameConcept();
            gameConceptPanel.gameConcept = concept;
            gameConceptPanel.SetPanel(concept);
            //Debug.Log("GameConcept added to panel"+concept.gameConceptName);
        }
        
    }

    public void WaitButton()
    {
        if (player.cash > 0)
        {

            float cost = player.cash * .05f;
            player.loseCash(cost);
            SetPanels();
        }
    }

}
