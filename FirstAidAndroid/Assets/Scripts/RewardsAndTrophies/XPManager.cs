using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPManager : MonoBehaviour
{
    public static XPManager instance;

    public string XPSaveKey = "xskey";
    private int currentXPCount { set => SaveXPvalue(value); get => LoadCurrentXPCount(); }


    [SerializeField] private int perCorrectAnswerXPgained = 10;

    public int CurrentXPCount {  get => currentXPCount; }

    public int LoadCurrentXPCount()
    {
        return PlayerPrefs.GetInt(XPSaveKey);
    }

    public void SaveXPvalue(int xp)
    {
        PlayerPrefs.SetInt(XPSaveKey, xp);
    }

    public void UpdateCurrentXPCountAfterLevelCompletion(int numberOfRightAnswers)
    {
        int result = 0;
        if (numberOfRightAnswers < 4)
        {
            result = perCorrectAnswerXPgained * numberOfRightAnswers;
        }
        else {
            result = 150; // all correct answers for 2 levels can result 300 xp points which is required to earn a trophy
        }
        
        currentXPCount += result;
    }

    public void ResetXP() {
        currentXPCount = 0;
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



}
