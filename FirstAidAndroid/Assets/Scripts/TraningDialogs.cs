using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TraningDialogs : MonoBehaviour
{
    public UnityEvent DialogsCompletedEvent;

    public GameObject[] Dialogs;

    private int currentPage = 0;
    [SerializeField] private bool firstTouch=true; 


    public void NextPage()
    {
        if (firstTouch)
        {
            firstTouch = false;
        }
        else
        {
            currentPage++;
            Dialogs[0].GetComponentInChildren<Text>().text = currentPage.ToString();
        }

    }


}
