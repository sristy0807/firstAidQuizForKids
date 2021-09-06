using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    public bool audioMuted;


    public static AudioManager instance;

    public void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        SoundMuteControl(PlayerPrefs.GetInt("_sound"));
    }

    public void PlayAudio(int id)
    {
        if (!audioMuted)
        {
            AudioSource _sc = GetComponent<AudioSource>();
            if (_sc.enabled)
            {
                _sc.PlayOneShot(audioClips[id]);
            }
            else
            {

                GameObject mainCam = GameObject.Find("Main Camera");

                AudioSource _newsc = mainCam.gameObject.GetComponent<AudioSource>();
               

                if ( _newsc != null)
                {
                    _newsc.PlayOneShot(audioClips[id]);
                }
                else
                {
                    _newsc = mainCam.AddComponent<AudioSource>() as AudioSource;
                    _newsc.PlayOneShot(audioClips[id]);
                }
            }

   
        }
    }
    

    private void Update()
    {
        if(PlayerPrefs.GetInt("_music") == 0)
        {
            audioMuted = false;
        }
        else
        {
            audioMuted = true;
        }
    }

    public void SoundMuteControl(int id)
    {
        AudioSource sc = GetComponent<AudioSource>();
        if (id == 0)
        {
            sc.enabled = true;
        }
        else
        {
            sc.enabled = false;
        }
        Debug.Log("scource: " + id);
    }
}
