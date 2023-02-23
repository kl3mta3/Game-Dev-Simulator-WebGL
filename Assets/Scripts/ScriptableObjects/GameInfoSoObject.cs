using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenuAttribute(fileName = "GameInfoSO", menuName = "GameInfoSO")]
public class GameInfoSoObject : ScriptableObject
{
    [SerializeField]
    internal bool isNewGame;
    [SerializeField]
    internal bool isContinuedGame;
}
