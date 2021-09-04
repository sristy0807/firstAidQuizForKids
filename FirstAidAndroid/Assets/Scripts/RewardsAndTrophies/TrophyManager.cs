using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrophyManager : MonoBehaviour
{
    public static TrophyManager instance;

    public TrophyScriptableObject[] Trophies;

   
    public int NextTrophyID
    {
        get => GetNextTrophyID();
    }
    private int GetNextTrophyID()
    {
        int id = -1;
        for (int i = 0; i < Trophies.Length; i++)
        {
            if (!Trophies[i].trophyAchieved)
            {
                id = i;
                break;
            }
        }
        return id;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

   

    public bool isNewTrophyAvailableToClaim(int xp)
    {
        if (GetNextTrophyID() < 0)
        {
            Debug.Log("all trophies found");
            return false;
        }
        else
        {
            Debug.Log("next trophy " + GetNextTrophyID());
            if (xp >= Trophies[GetNextTrophyID()].requiredXP)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    //called when trophy is claimed
    public void AssignNewTrophy(string key)
    {
        PlayerPrefs.SetInt(key, 1);
        XPManager.instance.ResetXP();
    }

}
