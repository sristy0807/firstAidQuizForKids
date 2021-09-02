using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StarAnimation : MonoBehaviour
{
    public GameObject[] Stars;
    public Text[] rewardTexts;
    public Image CoinImage;

    private int curentStarCount;

    private void Start()
    {
   //     PlayAnimation(2);
    }
    public void PlayAnimation(int starCount)
    {
        StartCoroutine(PlayStarAnimation(starCount));
    }

    IEnumerator PlayStarAnimation(int starCount) {
        CoinImage.DOFade(1, .5f);
        rewardTexts[starCount-1].DOFade(1, 0.5f);
        curentStarCount = starCount;
        for (int i = 0; i < starCount; i++)
        {

            Stars[i].GetComponent<RectTransform>().DOScale(new Vector3(1, 1, 1), 0.5f);
            yield return new WaitForSeconds(0.5f);
         //   ReverseAnimation();

        }
        
    }

    private void  ReverseAnimation()
    {
        CoinImage.DOFade(0, .1f);
        rewardTexts[curentStarCount - 1].DOFade(0, 0.05f);

        for (int i = 0; i < curentStarCount; i++)
        {

            Stars[i].GetComponent<RectTransform>().DOScale(new Vector3(0, 0, 0), 0.05f);
           

        }
    }
    public void AllReset()
    {
        ReverseAnimation();
    }

}
