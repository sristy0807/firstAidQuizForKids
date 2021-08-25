using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class LevelCompletePanel : MonoBehaviour
{
    public UnityEvent NextLevelAvailableEvent;
    public UnityEvent LastLevelCompletedEvent;

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
