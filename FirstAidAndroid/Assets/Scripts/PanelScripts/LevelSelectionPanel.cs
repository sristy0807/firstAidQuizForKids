using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionPanel : MonoBehaviour
{
    public HorizontalListChanger hList;
    public LevelLockedUnlockedCheck[] levelButtons;
    

    public void InitialState()
    {
        hList.Reset();
      
    }
}
