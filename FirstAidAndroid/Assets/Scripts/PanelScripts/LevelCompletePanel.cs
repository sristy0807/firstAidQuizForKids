using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelCompletePanel : MonoBehaviour
{
    public UnityEvent NextLevelAvailableEvent;
    public UnityEvent LastLevelCompletedEvent;
    public UnityEvent TrophyAvailableToClaimEvent;

    public int correctAnswersForThisCompletedLevel;

    public StarAnimation starAnimation;
    public PlayerProgress playerProgress;
    public TrophyCalimingPanel trophyCalimingPanel;
    public ProgressMeter progressMeter;
    

    public Text RewardPointText;


    //values required on this panel appearance
    public void SceneData()
    {
        UpdateRewardPointText();
    }

    private void UpdateRewardPointText() {
        RewardPointText.text = playerProgress.GetRewardPoint().ToString();
    }


    public void OnThisPanelAppearanceCompleted()
    {
        //play star animation
        starAnimation.PlayAnimation(correctAnswersForThisCompletedLevel-1); //star = right answer -1

        // update reward points and add points in UI - show UI animation
        RewardPointManager.instance.UpdateCurrentCoinCoutAfterLevelCompletion(correctAnswersForThisCompletedLevel - 1);
        UpdateRewardPointText();

        // add xp and show xp animation if this level is applicable
        if (GameManager.instance.CurrentLevel == (TrophyManager.instance.NextTrophyID+1)*2 || GameManager.instance.CurrentLevel == (TrophyManager.instance.NextTrophyID *2) + 1)
        {
            Debug.Log("Xp so far:  " + XPManager.instance.CurrentXPCount);
            float xpCountBeforeUpdate = XPManager.instance.CurrentXPCount;
            XPManager.instance.UpdateCurrentXPCountAfterLevelCompletion(correctAnswersForThisCompletedLevel);
            float xpCountUpdated = XPManager.instance.CurrentXPCount;
            Debug.Log("Xp so far:  " + XPManager.instance.CurrentXPCount);

            StartCoroutine(PlayProgressMeterAnimation(xpCountBeforeUpdate, xpCountUpdated, TrophyManager.instance.Trophies[TrophyManager.instance.NextTrophyID].requiredXP));
        }
        else {
            Debug.Log("No XP for this level " + GameManager.instance.CurrentLevel + ", xp available for levels  " + (TrophyManager.instance.NextTrophyID + 1) * 2 + ", " + ((TrophyManager.instance.NextTrophyID * 2) + 1));
        }

        

        //if new trophy achievable, show trophy claiming animation. update trophy manager;
      //  CheckingTrophyAvailability(); - this is now called on star animation completed event
    }

    public void CheckingTrophyAvailability() {
        if (TrophyManager.instance.isNewTrophyAvailableToClaim(XPManager.instance.CurrentXPCount))
        {
            Debug.Log("New trophy available");
            TrophyAvailableToClaimEvent.Invoke();
            trophyCalimingPanel.InitializeTrophyClaimPanel(TrophyManager.instance.Trophies[TrophyManager.instance.NextTrophyID]);
        }
        else
        {
            Debug.Log("NO trophy available");
            return;
        }
    }

    IEnumerator PlayProgressMeterAnimation(float initialValue, float fillValue, float maxValue)
    {
        progressMeter.gameObject.SetActive(true);
        float currentFillValue = initialValue;
        
        while(currentFillValue < fillValue)
        {
            progressMeter.IncreaseFillValue(currentFillValue, maxValue);
            currentFillValue += 0.1f;
        }
        yield return null;
    }

    public void OnThisPanelDisAppear()
    {
        starAnimation.AllReset();
        progressMeter.gameObject.SetActive(false);
    }


    public void OnClickNextButton()
    {
        if(GameManager.instance.CurrentLevel == 10)
        {
            LastLevelCompletedEvent.Invoke(); // panel change to all levels completed panel
        }
        else
        {
            GameManager.instance.NewActiveLevelSelected(GameManager.instance.CurrentLevel + 1);
            NextLevelAvailableEvent.Invoke(); // panel change to quiz panel
        }
    }

  
    
}
