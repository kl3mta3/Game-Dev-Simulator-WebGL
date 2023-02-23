using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "New GameConcept Database", menuName = "Database/GameConcept")]
    public class GameConceptDatabaseObject :ScriptableObject, ISerializationCallbackReceiver
    {
        public GameConcept[] GameConcepts;

        [ContextMenu("Update ID's")]
        public void UpdateID()
        {
            for (int i = 0; i < GameConcepts.Length; i++)
            {
                if (GameConcepts[i].gameConceptId != i)
                {
                    GameConcepts[i].gameConceptId = i;
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

    public GameConcept GetRandomGameConcept()
    {

        return GameConcepts[Random.Range(0, GameConcepts.Length)];
    }
}

