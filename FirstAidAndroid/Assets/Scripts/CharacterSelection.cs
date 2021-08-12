using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] Characters;
    public PlayerProgress playerProgress;

    private int onFocus = 0;

    private void Start()
    {
        SelectFocusedCharacter();
    }


    public void ChangeCharacter() {
        if(onFocus == 0) {
            onFocus = 1;
        }
        else
        {
            onFocus = 0;
        }

        SelectFocusedCharacter();
    }

    public void SelectFocusedCharacter() {
        for (int i = 0; i < Characters.Length; i++)
        {
            if (i == onFocus)
            {
                Characters[i].gameObject.SetActive(true);
            }
            else
            {
                Characters[i].gameObject.SetActive(false);
            }
        }
    }

    public void OnClickSelectCharacter() {
        playerProgress.SetCharacter(onFocus);
    }


}
