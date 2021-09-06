using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressMeter : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    public void IncreaseFillValue(float fillValue, float maxValue)
    {
        fillImage.fillAmount = Mathf.Clamp (fillValue / maxValue,0.1f,1f);
    }
}
