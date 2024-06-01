using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_Switch_Music_Ctrl : MonoBehaviour
{
    public GameObject btn_On;
    public GameObject btn_Off;
    public AudioSource _audio;
    public bool isOn;
    private void Awake()
    {
        _audio = SoundManager.Instance.musicSource;
        //isOn = SaveAndLoadMusic.Instance.LoadIsSoundOn();
        //Debug.Log(isOn);

    }
    public void Update()
    {
        Check();
    }
    public void turnOffSound()
    {
        isOn = false;
        _audio.Stop();
        Debug.Log("ActionOff!");
    }

    public void turnOnSound()
    {
        isOn = true;
        _audio.Play();
        Debug.Log("ActionOn!");
    }
    public void Check()
    {
        if (!isOn)
        {
            btn_Off.SetActive(true);
            btn_On.SetActive(false);
        }
        else
        {
            btn_Off.SetActive(false);
            btn_On.SetActive(true);
        }
    }
}
