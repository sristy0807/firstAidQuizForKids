using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;

public class QuizPanel : MonoBehaviour
{

    const int NumberOfQuestions = 4;
    [SerializeField] private QuestionData[] questionDataForThisLevel = new QuestionData[NumberOfQuestions];
    [SerializeField] private int runningQuestionIndex;
    [SerializeField] private int rightAnswerID;
    [SerializeField] private int rightAnswersCount;
    [SerializeField] private int currentLevel;

    public Text LevelText;
    public Text QuestionText;
    public Text[] AnswerTexts;

    public GameObject AnswerButtonOverPanel;
    public GameObject wrongAnswerAnimation;


    public UnityEvent LevelCompleteEvent;
    public UnityEvent GameOverEvent;

    public LevelCompletePanel levelCompletePanel;
    public TextToSpeech textToSpeech;
    

    public void GetQuestionForCurrentLevel(int _level)
    {
        currentLevel = _level;
        LevelText.text = "Level " + _level;
        _level = _level - 1;
        var random = new System.Random();
        var qArray = Enumerable.Range(0, 9).OrderBy(t => random.Next()).Take(NumberOfQuestions).ToArray();
        
        for(int i = 0; i < qArray.Length; i++)
        {
            questionDataForThisLevel[i] = DataController.instance.allRoundData[_level].questions[qArray[i]];
        }

        NewQuestion();

    }

    public void PlayTheFirstQuestionAfterPanelAppeared()
    {
        textToSpeech.PlaySpeech(questionDataForThisLevel[0].questionText);
    }

    public void NewQuestion() {

        QuestionText.text = questionDataForThisLevel[runningQuestionIndex].questionText;
        if (runningQuestionIndex > 0){
            textToSpeech.PlaySpeech(questionDataForThisLevel[runningQuestionIndex].questionText);
        }
            for(int i =0; i < 4; i++)
            {
                AnswerTexts[i].text = questionDataForThisLevel[runningQuestionIndex].answers[i].answerText;
                if (questionDataForThisLevel[runningQuestionIndex].answers[i].isCorrect)
                {
                    rightAnswerID = i;
                }
            }
            runningQuestionIndex++;
        
       
    }

    public void AnswerClicked(int id)
    {
        bool isCorrect=false;
        AnswerButtonOverPanel.gameObject.SetActive(true);
        if (id == rightAnswerID)
        {
            Debug.Log("right Answer");
            rightAnswersCount++;
            AudioManager.instance.PlayAudio(0);
            AnswerTexts[id].GetComponent<Text>().color = Color.green;
            isCorrect = true;

        }
        else
        {
            Debug.Log("wrong Answer");
            AudioManager.instance.PlayAudio(1);
            AnswerTexts[id].color = Color.red;
            AnswerTexts[rightAnswerID].color = Color.green;
            isCorrect = false;
        }
        
        AnswerButtonOverPanel.GetComponent<QuizAnswerFooterPanel>().QuizAnswerResult(isCorrect, currentLevel, GameManager.instance.playerProgress.GetCharacterID());
        StartCoroutine(CompleteAnimationForNextQuestion());
    }

    IEnumerator CompleteAnimationForNextQuestion()
    {
        yield return new WaitForSeconds(2f);
        
       foreach(Text text in AnswerTexts)
        {
            text.color = Color.white;
        }
        if (runningQuestionIndex < NumberOfQuestions)
        {
            NewQuestion();
        }
        else
        {
            runningQuestionIndex = 0;
            LevelComplete();
        }
        AnswerButtonOverPanel.gameObject.SetActive(false);
    }

    public void LevelComplete()
    {
        if (rightAnswersCount < 2)
        {
            rightAnswersCount = 0;
            GameOverEvent.Invoke();
        }
        else
        {
            levelCompletePanel.correctAnswersForThisCompletedLevel = rightAnswersCount;
            rightAnswersCount = 0;
            LevelCompleteEvent.Invoke();
        }
    }

    

    public void ResetLevelValues()
    {
        runningQuestionIndex=0;
        rightAnswerID=0;
        rightAnswersCount=0;
        currentLevel=0;
    }
    

}
