using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_Switch_Sound_Ctrl : MonoBehaviour
{
    public GameObject btn_On;
    public GameObject btn_Off;
    public AudioSource _audio;
    public bool vfxCondition;
    private void Awake()
    {
        _audio = SoundManager.Instance.sfxSoucre;
        //_audio.mute = vfxCondition;
    }
    public void Update()
    {
        Check();
    }

    public void turnOffSound()
    {
        vfxCondition = true;
        //Debug.LogError(vfxCondition);
    }
    public void turnOnSound()
    {
        vfxCondition = false;
        //Debug.LogError(vfxCondition);
    }
    public void Check()
    {
        _audio.mute = vfxCondition;
        Debug.Log(vfxCondition);
        if (vfxCondition)
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
