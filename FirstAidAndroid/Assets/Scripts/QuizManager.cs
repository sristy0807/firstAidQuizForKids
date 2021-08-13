using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance;

    private void Start()
    {
        instance = this;
    }

    public void GetQuestion(int _level)
    {
        var random = new System.Random();
        var intArray = Enumerable.Range(0, 9).OrderBy(t => random.Next()).Take(4).ToArray();
        int j = 0;
        foreach(var n in intArray)
        {
            j++;
            Debug.Log(j + ". " +_level+", "+  DataController.instance.allRoundData[_level].questions[n].questionText);
        }
    }
}
