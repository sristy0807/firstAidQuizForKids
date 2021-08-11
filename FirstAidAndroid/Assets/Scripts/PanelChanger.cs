using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelChanger : MonoBehaviour
{
    public GameObject[] UIPanels;

    public static int currentActivePanelID=-1;

    public void GoToPanel(int id)
    {
        if (id < UIPanels.Length)
        {
            UIPanels[id].gameObject.SetActive(true);
            try
            {
                UIPanels[currentActivePanelID].gameObject.SetActive(false);
            }
            catch
            {
                Debug.Log("This is the first panel opening");
            }
            currentActivePanelID = id;
        }
        else
        {
            Debug.Log("No where to go");
        }
            
      
    }

    public void Quit()
    {
        Application.Quit();
    }

}
