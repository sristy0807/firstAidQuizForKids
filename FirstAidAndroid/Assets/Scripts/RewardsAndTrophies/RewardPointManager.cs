using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardPointManager : MonoBehaviour
{
    public static RewardPointManager instance;

    public string RewardPointSaveKey = "rpskey";
    private int currentCoinCount { set => SaveCurrentCoinCount(value); get => LoadCurrentCoinCount(); }

    public int CurrentCoinCount { get => currentCoinCount; }

    public int  LoadCurrentCoinCount()
    {
        return PlayerPrefs.GetInt(RewardPointSaveKey);
    }

    public void SaveCurrentCoinCount(int coinCount)
    {
        PlayerPrefs.SetInt(RewardPointSaveKey, coinCount);
    }

    public void UpdateCurrentCoinCoutAfterLevelCompletion(int starCount)
    {
        currentCoinCount += GetRewardPointValueForLevelCompletion(starCount);
    }

    public int GetRewardPointValueForLevelCompletion(int starCount)
    {
        int result = 0;
        switch (starCount)
        {
            case 0:
                break;
            case 1:
                result = 5;
                break;
            case 2:
                result = 15;
                break;
            case 3:
                result = 25;
                break;
            default:
                break;
        }

        return result;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


     


}
