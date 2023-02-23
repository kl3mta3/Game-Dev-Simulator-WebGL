using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "CharacterSO", menuName = "CharacterCharacterSO")]
public class CharacterSoObject : ScriptableObject
{
    [SerializeField]
    internal string playerName;

    [SerializeField]
    internal float modelingSKill;
    [SerializeField]
    internal float codongSKill;
    [SerializeField]
    internal float designSKill;
    [SerializeField]
    internal float marketingSKill;

    [SerializeField]
    internal float playerTaxRate;
    
    [SerializeField]
    internal float cash;

    [SerializeField]
    internal bool isUnity;

    [SerializeField]
    internal bool isUnreal;

    [SerializeField]
    internal bool isOwnEngine;
    [SerializeField]
    internal SoundManager soundManager;
}
