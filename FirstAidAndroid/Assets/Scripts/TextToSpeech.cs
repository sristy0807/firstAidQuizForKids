using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextToSpeech : MonoBehaviour
{
    //public string txt;
  
    public AudioSource audio_s;
    

    // Start is called before the first frame update

    public void PlaySpeech(string t)
    {
        StartCoroutine(DownloadAudio(t));
    }

    public void StopSpeech()
    {
        audio_s.Stop();
    }

    IEnumerator DownloadAudio(string t)
    {
        string url = "https://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen=32&client=tw-ob&q=" + t + "&tl=En-gb";
        WWW ww = new WWW(url);
        yield return ww;

        audio_s.clip = ww.GetAudioClip(false, true, AudioType.MPEG);
        audio_s.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
