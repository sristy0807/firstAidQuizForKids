using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerProgress playerProgress;

    private int currentLevel;
    private int maxCompletedLevel;

    //panel references
    public TrainingPanel trainingPanel;
    public QuizPanel quizPanel;

    public int CurrentLevel { get => currentLevel;  }
    public int MaxLevel { get => maxCompletedLevel; set => maxCompletedLevel = value; }
    public int CurrentUnlockedMaxLevel
    {
        get
        {
            int lvl = 10;
            if (TrophyManager.instance.NextTrophyID > 0)
            {
                lvl = (TrophyManager.instance.NextTrophyID + 1) * 2;
            }
            return lvl;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    //this is called when level button is clicked, this method is to update every places where current level is used
    public void NewActiveLevelSelected(int id)
    {
        currentLevel = id;
        trainingPanel.UpdateLevelText(id);
        quizPanel.GetQuestionForCurrentLevel(id);
    }
    
}
