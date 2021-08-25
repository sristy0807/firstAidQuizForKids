using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyPanel : MonoBehaviour
{
    public TrophyDetails[] trophyDetails;

    public void TrophyPanelInitializer()
    {
        foreach(TrophyDetails td in trophyDetails)
        {
            td.TrophyDetailsInitializer();
        }
    }
}
