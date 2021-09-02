using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelCompletePanel : MonoBehaviour
{
    public UnityEvent NextLevelAvailableEvent;
    public UnityEvent LastLevelCompletedEvent;

    public int correctAnswersForThisCompletedLevel;
    public StarAnimation starAnimation;
    public PlayerProgress playerProgress;

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

        // add xp and show animation
        //if new trophy achievable, show trophy claiming animation. update trophy manager;
    }

    public void OnThisPanelDisAppear()
    {
        starAnimation.AllReset();
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
