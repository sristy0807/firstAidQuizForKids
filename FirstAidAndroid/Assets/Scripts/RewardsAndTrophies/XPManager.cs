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
        int result = perCorrectAnswerXPgained * numberOfRightAnswers;
        currentXPCount += result;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



}
