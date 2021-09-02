using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class QuizAnswerFooterPanel : MonoBehaviour
{
    public Sprite[] CharacterMaleHappy;
    public Sprite[] CharacterFemaleHappy;

    public Sprite[] CharacterMaleSad;
    public Sprite[] CharacterFemaleSad;

    public Image CharacterIcon;

    public Text ResultText;

    public void QuizAnswerResult(bool isCorrect, int levelID, int characterID)
    {
        levelID = levelID - 1; //levelID starts from 1 so 1 is deducted
        if (isCorrect)
        {
            ResultText.text = "Right Answer";
            ResultText.color = Color.green;
            if(characterID == 0) {
                CharacterIcon.sprite = CharacterMaleHappy[levelID];
            }
            else
            {
                CharacterIcon.sprite = CharacterFemaleHappy[levelID];
            }

        }
        else
        {
            ResultText.text = "Wrong Answer";
            ResultText.color = Color.red;
            if (characterID == 0)
            {
                CharacterIcon.sprite = CharacterMaleSad[levelID];
            }
            else
            {
                CharacterIcon.sprite = CharacterFemaleSad[levelID];
            }
        }

        CharacterIcon.DOFade(1, 0.2f);
        ResultText.DOFade(1, 0.2f);
    }

    private void OnDisable()
    {
        CharacterIcon.DOFade(0, 0f);
        ResultText.DOFade(0, 0f);
    }
    public void ResetAll() {

    }


}
