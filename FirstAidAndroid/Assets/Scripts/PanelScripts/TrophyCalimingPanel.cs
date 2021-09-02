using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophyCalimingPanel : MonoBehaviour
{
    public Image TrophyImage;
    public Text TrophyTitle;

    
    private string trophyKey;

    public void InitializeTrophyClaimPanel(TrophyScriptableObject newTrophy)
    {
        TrophyTitle.text = newTrophy.title;
        TrophyImage.sprite = newTrophy.trophyIcon;
        trophyKey = newTrophy.trophyAchievedKey;
    }

    public void OnClickClaimButton()
    {
        //trophy claimed
        TrophyManager.instance.AssignNewTrophy(trophyKey);

        //show some animation
        
        //go to level page

        //unlock next levels
    }


}
