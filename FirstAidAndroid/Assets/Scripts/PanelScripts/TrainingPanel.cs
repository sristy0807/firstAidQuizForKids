using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingPanel : MonoBehaviour
{
    public Text ShowLevel;
    public GameObject[] LevelTrainingDialogs;

    public void UpdateLevelText(int levelID)
    {
        ShowLevel.text = "Level " + levelID;
    }

    public void EnableLevelTrainingData(int level)
    {
        for(int i = 0; i < LevelTrainingDialogs.Length; i++)
        {
            if(i == level - 1)
            {
                LevelTrainingDialogs[i].gameObject.SetActive(true);
                LevelTrainingDialogs[i].GetComponent<TrainingDialogs>().currentPage = 0;
            }
            else
            {
                LevelTrainingDialogs[i].gameObject.SetActive(false);
            }
        }
    }
}
