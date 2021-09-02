using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trophy", menuName = "Trophy")]
public class TrophyScriptableObject : ScriptableObject
{
    public string title;
    public Sprite trophyIcon;
    public int requiredXP;
    public string trophyAchievedKey;

    public bool trophyAchieved {
        get
        {
            if (PlayerPrefs.GetInt(trophyAchievedKey) == 1) {
                return true;
             }
            else {
                return false;
            }

        }
    }
}
