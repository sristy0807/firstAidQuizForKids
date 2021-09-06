using UnityEngine;
using UnityEngine.UI;

public class AudioControler : MonoBehaviour
{

    public GameObject SoundButton;
    

    public Text SoiundBtnText;
   


    public string[] SoundBtnTexts;
    


    public string SoundKey = "_sound";
    


    public static AudioControler instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SoiundBtnText.GetComponent<Text>().text = SoundBtnTexts[PlayerPrefs.GetInt(SoundKey)];
        
    }

    public void OnClickSoundBtn()
    {

        if (PlayerPrefs.GetInt(SoundKey) == 1)
        {
            PlayerPrefs.SetInt(SoundKey, 0);
            
        }
        else
        {
            PlayerPrefs.SetInt(SoundKey, 1);
        }

        AudioManager.instance.SoundMuteControl(PlayerPrefs.GetInt(SoundKey));
        SoiundBtnText.text = SoundBtnTexts[PlayerPrefs.GetInt(SoundKey)];

    }

    

   


    // Update is called once per frame
    void Update()
    {
        
    }
}
