using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGamePiece : MonoBehaviour
{
    [SerializeField]
    internal Image image;
    
    [SerializeField]
    internal MarketingMiniGamePanel marketingMiniGamePanel;
    [SerializeField]
    internal Player player;
    
    internal GameObject thisPiece;

    internal bool isFaceNovelPiece = false;
    internal bool isTikTikPiece = false;
    internal bool isBooglelPiece = false;
    internal bool isEweTubePiece = false;

    public void Start()
    {
        thisPiece = gameObject;
    }


    public void ClickPiece()
    {
        if (isFaceNovelPiece)
        {
            marketingMiniGamePanel.faceFlyerBonus += 1f;

            thisPiece.SetActive(false);
        }
        else if (isTikTikPiece)
        {
            marketingMiniGamePanel.tikTikBonus += 1f;
            thisPiece.SetActive(false);
        }
        else if (isBooglelPiece)
        {
            marketingMiniGamePanel.boogleBonus += 1f;
            thisPiece.SetActive(false);
        }
        else if (isEweTubePiece)
        {
            marketingMiniGamePanel.eweTubeBonus += 1f;
            thisPiece.SetActive(false);
        }
        
        if (player.soundManager != null)
        {
            player.soundManager.PlayButton3Sound();
        }

    }



}
