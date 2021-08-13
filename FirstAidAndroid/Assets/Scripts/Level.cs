using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int thisLevel;

    public void SetLevel()
    {
        QuizManager.instance.GetQuestion(thisLevel);
        Debug.Log("This level: " + thisLevel);
    }
}
