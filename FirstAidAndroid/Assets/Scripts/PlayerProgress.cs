using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerProgress : MonoBehaviour
{
    public int totalScore;
    public int currentLevelToPlay;

    string scoreKey = "scoreKey";

    public void AddNewScore(int score, int level)
    {
        int _score = PlayerPrefs.GetInt(scoreKey);
        _score += score + (10 * level);

        PlayerPrefs.SetInt(scoreKey, _score);
    }

    public int GetTotalScore()
    {
        int _score = PlayerPrefs.GetInt(scoreKey);

        return _score;
    }
}