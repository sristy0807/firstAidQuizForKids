using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;


public class PlayGames : MonoBehaviour
{
    
    string leaderboardID = "CgkIgNzl7skaEAIQAA";
    

    string achievementID = "";
    static bool active = false;

    public static PlayGames instance;

    private void Awake()
    {

        if (!active)
        {
            DontDestroyOnLoad(this);
            active = true;
            instance = this;
        }
        else
        {
            Destroy(this);
        }


        try
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.Activate();
            Social.localUser.Authenticate((bool success) => { });
        }
        catch (Exception exception)
        {
            Debug.Log(exception);
        }
    }

    public void AddScoreToLeaderboard (int _score)
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(Convert.ToInt64( _score), leaderboardID, success => { });
        }
    }

    //public void AddScoreToLeaderboardMed(float _score)
    //{
    //    if (Social.localUser.authenticated)
    //    {
    //        Social.ReportScore(Convert.ToInt64(_score), leaderboardIDMed, success => { });
    //    }
    //}

    //public void AddScoreToLeaderboardHard(float _score)
    //{
    //    if (Social.localUser.authenticated)
    //    {
    //        Social.ReportScore(Convert.ToInt64(_score), leaderboardIDHard, success => { });
    //    }
    //}



    public void ShowLeaderboard()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowLeaderboardUI();
        }
    }

    public void ShowAchievements()
    {
        if (Social.localUser.authenticated)
        {
            Social.ShowAchievementsUI();
        }
    }

    public void UnlockAchievement()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportProgress(achievementID, 100f, success => { });
        }
    }
}