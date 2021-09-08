using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TrainingDialogs : MonoBehaviour
{
    public UnityEvent DialogsCompletedEvent;

    public string[] Dialogs;
    public Text DialogBox;

    public int currentPage = 0;
    [SerializeField] private bool firstTouch=true; 


    public void NextPage()
    {
        if (firstTouch)
        {
            firstTouch = false;
        }
        else
        {
            if (currentPage < Dialogs.Length)
            {
                DialogBox.text = Dialogs[currentPage];
                currentPage++;
            }
            else
            {
                DialogsCompletedEvent.Invoke();
            }
            
            
        }

    }


}
