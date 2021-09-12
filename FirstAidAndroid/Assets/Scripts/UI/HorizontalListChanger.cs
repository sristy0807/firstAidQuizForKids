using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalListChanger : MonoBehaviour
{
    public RectTransform[] elements;
    public GameObject RightArrow;
    public GameObject LeftArrow;

    [SerializeField] private int activeID=0;

    public void Reset()
    {
        foreach(RectTransform rt in elements)
        {
            rt.gameObject.SetActive(false);
        }
       ;
        activeID = 0;
        elements[activeID].gameObject.SetActive(true);
        LeftArrow.gameObject.SetActive(false);
    }

    public void OnClickRightArrow()
    {
        activeID++;
        if (!LeftArrow.activeInHierarchy)
        {
            LeftArrow.gameObject.SetActive(true);
        }


        if(activeID == elements.Length - 1)
        {
            RightArrow.gameObject.SetActive(false);

        }

        elements[activeID - 1].gameObject.SetActive(false);
        elements[activeID].gameObject.SetActive(true);

    }


    public void OnClickLeftArrow()
    {
        activeID--;
        if (!RightArrow.activeInHierarchy)
        {
            RightArrow.gameObject.SetActive(true);
        }


        if (activeID == 0)
        {
            LeftArrow.gameObject.SetActive(false);

        }

        elements[activeID + 1].gameObject.SetActive(false);
        elements[activeID].gameObject.SetActive(true);

    }




}
