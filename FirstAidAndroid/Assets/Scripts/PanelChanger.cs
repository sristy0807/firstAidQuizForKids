using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelChanger : MonoBehaviour
{
    public GameObject[] UIPanels;

    public static int currentActivePanelID;

    public void GoToPanell(int id)
    {
        if (id < UIPanels.Length)
        {
            UIPanels[id].gameObject.SetActive(true);
            UIPanels[currentActivePanelID].gameObject.SetActive(false);
            currentActivePanelID = id;
        }
        else
        {
            Debug.Log("No where to go");
        }
            
      
    }


}
