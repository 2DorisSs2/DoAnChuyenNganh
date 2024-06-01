using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
    public void Awake()
    {
        if (Instance != this)
        {
            
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        bool isOn = SaveAndLoadMusic.Instance.LoadIsSoundOn();
        Debug.Log(isOn);
        PlayMusic("Theme");
        if (!isOn)
        {
            musicSource.Stop();
        }
    }

    public Sound[] listMusicSounds, listSFXSounds;
    public AudioSource musicSource, sfxSoucre;

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(listMusicSounds, x => x.name == name);
        if (s == null) return;
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(listSFXSounds, x => x.name == name);
        if (s == null) return;
        else
        {
            sfxSoucre.clip = s.clip;
            sfxSoucre.Play();
        }
    }
}
