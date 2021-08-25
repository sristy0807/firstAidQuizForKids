using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerProgress : MonoBehaviour
{
    public int totalScore;
    public int currentLevelToPlay;
    public int SelectedCharacter;

    string scoreKey = "scoreKey";
    string characterKey = "character";

    public void AddNewScore(int score)
    {
        int _score = PlayerPrefs.GetInt(scoreKey);
        _score += score ;

        PlayerPrefs.SetInt(scoreKey, _score);
    }

    public int GetTotalScore()
    {
        int _score = PlayerPrefs.GetInt(scoreKey);

        return _score;
    }

    public void SetCharacter(int id)
    {
        SelectedCharacter = id;
        PlayerPrefs.SetInt(characterKey, id);
    }

    public int GetCharacterID()
    {
        int id = PlayerPrefs.GetInt(scoreKey);
        return id;
    }

    public int GetRewardPoint()
    {
        return RewardPointManager.instance.CurrentCoinCount;
    }

    
}