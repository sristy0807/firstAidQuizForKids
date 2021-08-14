using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingPanel : MonoBehaviour
{
    public Text ShowLevel;
    public Text TrainingText;

    public void UpdateLevelText(int levelID)
    {
        ShowLevel.text = "Level " + levelID;
    }
}
