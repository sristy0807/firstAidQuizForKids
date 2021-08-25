using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyManager : MonoBehaviour
{
    public static TrophyManager instance;

    public TrophyScriptableObject[] Trophies;

    private int xpWhenLastTrophyWon;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {

        //OnLevelCompleteTrophyUpdate(XPManager.instance.CurrentXPCount);
        //foreach (TrophyScriptableObject trophy in Trophies)
        //{
        //    Debug.Log(trophy.name + "\n " + XPManager.instance.CurrentXPCount + ", achieved status: " + trophy.trophyAchieved);
        //}
        //XPManager.instance.UpdateCurrentXPCountAfterLevelCompletion(30);
        

    }


    private int GetNextTrophyID()
    {
        int id=-1; 
        for(int i = 0; i < Trophies.Length; i++)
        {
            if (!Trophies[i].trophyAchieved)
            {
                id = i;
                break;
            }
        }
        return id;
    }

    private bool isNewTrophyAvailable(int xp) {
        if (GetNextTrophyID() < 0)
        {
            Debug.Log("all trophies found");
            return false;
        }
        else
        {
            Debug.Log("next trophy " + GetNextTrophyID());
            if (xp > Trophies[GetNextTrophyID()].requiredXP)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private void AssignNewTrophy(string newTrophyKey) {
        PlayerPrefs.SetInt(newTrophyKey, 1);
    }


    public void OnLevelCompleteTrophyUpdate(int xp) {
        if (isNewTrophyAvailable(xp)) {
            AssignNewTrophy(Trophies[GetNextTrophyID()].trophyAchievedKey);
        }

    }



}
