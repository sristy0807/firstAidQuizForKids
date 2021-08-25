using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StarAnimation : MonoBehaviour
{
    public GameObject[] Stars;
    private void Start()
    {
        PlayAnimation(1);
    }
    public void PlayAnimation(int starCount)
    {
        StartCoroutine(PlayStarAnimation(starCount));
    }

    IEnumerator PlayStarAnimation(int starCount) {
        for (int i = 0; i < starCount; i++)
        {
            Stars[i].GetComponent<RectTransform>().DOScale(new Vector3(1, 1, 1), 0.5f);
            yield return new WaitForSeconds(.5f);

        }
        
    }

}
