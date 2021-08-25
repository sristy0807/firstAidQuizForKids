using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TrophyDetails : MonoBehaviour
{
    public TrophyScriptableObject trophy;
    public Image trophyImg;
    public Text trophyName;
    public Text trophyXP;
    public Image trophyClaimed;


    public void TrophyDetailsInitializer()
    {
        trophyImg.sprite = trophy.trophyIcon;
        trophyName.text = trophy.title;
        trophyXP.text = "xp needed " + trophy.requiredXP;
        if (trophy.trophyAchieved) {
            trophyClaimed.gameObject.SetActive(true);
        }
        else
        {
            trophyClaimed.gameObject.SetActive(false);
        }

    }
}
