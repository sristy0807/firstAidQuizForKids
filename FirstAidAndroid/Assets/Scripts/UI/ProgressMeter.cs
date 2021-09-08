using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ProgressMeter : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private Text XpText;

    public void IncreaseFillValue(float fillValue, float maxValue)
    {
        fillImage.fillAmount = Mathf.Clamp (fillValue / maxValue,0.1f,1f);
    }

    public void ShowXPtext(float currentXP, float maxXP)
    {
        currentXP = Mathf.Clamp(currentXP, 0, maxXP);
        string showXP = "XP " + currentXP + "/" + maxXP;
        XpText.text = showXP;
    }
}
