using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ProspectPanel : MonoBehaviour
{
    [SerializeField]
    internal FreeLanceProspect prospect;

    [SerializeField]
    internal GameObject hirePanel;
    [SerializeField]
    internal Player player;
    [SerializeField]
    internal TextMeshProUGUI prospectName;
    [SerializeField]
    internal Image prospectImage;
    [SerializeField]
    internal TextMeshProUGUI prospectCost;
    [SerializeField]
    internal TextMeshProUGUI gamesCompleted;

    [SerializeField]
    internal TextMeshProUGUI prospectModelingSkillText;
    [SerializeField]
    internal TextMeshProUGUI prospectCodingSkillText;
    [SerializeField]
    internal TextMeshProUGUI prospectDesignSkillText;
    [SerializeField]
    internal TextMeshProUGUI prospectMarketingSkillText;


    public void SetPanel(FreeLanceProspect prospect)
    {
        prospectName.text = prospect.prospectName;
        prospectImage.sprite = prospect.prospectImage;
        prospectCost.text = "$"+prospect.prospectCost.ToString();
        gamesCompleted.text = prospect.gamesCompleted.ToString();
        prospectModelingSkillText.text = prospect.marketingSkill.ToString();
        prospectCodingSkillText.text = prospect.codingSkill.ToString();
        prospectDesignSkillText.text = prospect.designSkill.ToString();
        prospectMarketingSkillText.text = prospect.marketingSkill.ToString();
    }



    public void HireFreeLance()
    {
        if (player.cash >= prospect.prospectCost)
        {
            player.HireFreelance(prospect);
            hirePanel.SetActive(false);
            //hireAFreeLancePanel.SetPanels();
        }
    }
}
