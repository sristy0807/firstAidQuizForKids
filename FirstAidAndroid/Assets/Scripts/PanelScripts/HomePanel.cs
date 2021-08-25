using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePanel : MonoBehaviour
{
    public PlayerProgress playerProgress;
    public Text RewardPointText;

    public void SceneData() {
        RewardPointText.text = playerProgress.GetRewardPoint().ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
