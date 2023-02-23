using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    internal SoundManager soundManager;
    [SerializeField]
    internal string playerName;

    [SerializeField]
    internal float playerLevel = 1;

    [SerializeField]
    internal float playerTaxRate;

    [SerializeField]
    internal float modelingSkill;
    [SerializeField]
    internal float codingSkill; 
    [SerializeField]
    internal float designSkill; 
    [SerializeField]
    internal float marketingSkill;

    [SerializeField]
    internal float modelingSkillBoost;
    [SerializeField]
    internal float codingSkillBoost;
    [SerializeField]
    internal float designSkillBoost;
    [SerializeField]
    internal float marketingSkillBoost;
    [SerializeField]
    internal float currentTeamSize=1;

    [SerializeField]
    internal float cash;

    [SerializeField]
    internal float reputation;

    [SerializeField]
    internal float popularity;

    [SerializeField]
    internal float gamesMade;

    [SerializeField]
    internal List<GameConcept> gamePortfolio = new List<GameConcept>();

    [SerializeField]
    internal GameConcept currentGame;
    [SerializeField]
    internal float currentGameCost;

    public void AddCash(float cashToAdd)
    {
        cash += cashToAdd;
    }

    public void AddReputation(float reputationToAdd)
    {
        reputation += reputationToAdd;
    }

    public void AddPopularity(float popularityToAdd)
    {
        popularity += popularityToAdd;
    }

    public void loseCash(float cashToAdd)
    {
        cash -= cashToAdd;
    }

    public void loseReputation(float reputationToAdd)
    {
        reputation -= reputationToAdd;
    }

    public void losePopularity(float popularityToAdd)
    {
        popularity -= popularityToAdd;
    }

    public void HireFreelance(FreeLanceProspect prospect)
    {
        float cost = prospect.prospectCost+(cash*.01f);
        loseCash(cost);
        currentGameCost += cost;
        modelingSkillBoost += prospect.modelingSkill + Mathf.Round(playerLevel * 1.5f);
        codingSkillBoost += prospect.codingSkill + Mathf.Round(playerLevel * 1.5f);
        designSkillBoost += prospect.designSkill + Mathf.Round(playerLevel * 1.5f);
        marketingSkillBoost += prospect.marketingSkill + Mathf.Round(playerLevel * 1.5f);
        currentTeamSize += 1;
        
    }
    
    public void ResetBoost()
    {


        modelingSkillBoost += 0;
        codingSkillBoost += 0;
        designSkillBoost += 0;
        marketingSkillBoost += 0;
        currentTeamSize += 1;

    }
}
