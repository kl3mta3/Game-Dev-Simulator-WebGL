using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "FreeLanceProspect", menuName = "FreeLanceProspect")]
public class FreeLanceProspect : ScriptableObject
{
    [SerializeField]
    internal string prospectName;
    [SerializeField]
    internal int prospectId;
    [SerializeField]
    internal Sprite prospectImage;
    [SerializeField]
    internal float prospectCost;
    [SerializeField]
    internal float gamesCompleted;
    [SerializeField]
    internal float modelingSkill;
    [SerializeField]
    internal float codingSkill;
    [SerializeField]
    internal float designSkill;
    [SerializeField]
    internal float marketingSkill;

    
}
