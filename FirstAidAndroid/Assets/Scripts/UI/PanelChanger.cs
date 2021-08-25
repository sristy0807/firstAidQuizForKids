using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
using System;

public class PanelChanger : MonoBehaviour
{

    public RectTransform ReferencePanel;
    public float duration = 0.25f;

    private Vector2 startPos;
    private RectTransform activePanel;

    private void Start()
    {
        startPos = ReferencePanel.position;
        ReferencePanel.DOAnchorPos(Vector2.zero, duration);
        activePanel = ReferencePanel;
        PanelInitalizer(ReferencePanel);
    }

    public void ChangePanel(RectTransform entryPanel)
    {
        activePanel.DOAnchorPos(new Vector2(-1302, 0), duration);
        entryPanel.DOAnchorPos(Vector2.zero, duration);
        activePanel = entryPanel;
        PanelInitalizer(entryPanel);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PanelInitalizer(RectTransform ePanel)
    {
        try
        {
            ePanel.GetComponent<UIPanel>().OnPanelIntitializeEvent.Invoke();
            Debug.Log("panel initialization called for " + ePanel.name);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        
    }

}
