using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LevelLockedUnlockedCheck : MonoBehaviour
{
    public int TrophyIDRequired;
    public UnityEvent OnLevelSelectionPageStartsEvent;

    private void OnEnable()
    {
        CheckLockStatus();
    }

    public void CheckLockStatus()
    {
        if(TrophyIDRequired> TrophyManager.instance.NextTrophyID)
        {
            if(TrophyManager.instance.NextTrophyID == -1)
            {
                GetComponent<Button>().interactable = true;
            }
            else
            {
                GetComponent<Button>().interactable = false;
            }
            
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
