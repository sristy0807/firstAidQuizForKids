using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Events;

public class DataController : MonoBehaviour
{
    public static DataController instance;
    public UnityEvent DataLoaded;

    public TextAsset jsonFile;
    public RoundData[] allRoundData;

    private int activeRoundID;
    private PlayerProgress playerProgress;

   
    public int GetTotalScore()
    {
        return playerProgress.totalScore;
    }

    public int GetCurrentLevel()
    {
        return playerProgress.currentLevelToPlay;
    }
  

    public int ActiveRoundID
    {
        get {
            activeRoundID = PlayerPrefs.GetInt("round");
            return activeRoundID;
        }
        set {
            PlayerPrefs.SetInt("round", value);
            activeRoundID = PlayerPrefs.GetInt("round");
           
        }
    }

    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start()
    {
      
        LoadGameData();
    
    }

    public RoundData GetCurrentRoundData()
    {
        return allRoundData[activeRoundID];
    }
    string filePath;
    void LoadGameData()
    {
       
        GameData loadedData = JsonUtility.FromJson<GameData>(jsonFile.text);
        allRoundData = loadedData.allRoundData;
        DataLoaded.Invoke();

    }
}
