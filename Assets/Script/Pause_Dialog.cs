using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Dialog : MonoBehaviour
{
    public Toggle_Switch_Music_Ctrl toggle_switch;
    public Toggle_Switch_Sound_Ctrl toggle_vfx;
    public void Awake()
    {
        toggle_switch = GetComponentInChildren<Toggle_Switch_Music_Ctrl>();
        toggle_vfx = GetComponentInChildren<Toggle_Switch_Sound_Ctrl>();
    }
    public void Show()
    {
        SoundManager.Instance.PlaySFX("Click");
        transform.gameObject.SetActive(true);
        Time.timeScale = 0f;
        toggle_switch.isOn = SaveAndLoadMusic.Instance.LoadIsSoundOn();
        toggle_vfx.vfxCondition = SaveAndLoadMusic.Instance.LoadIsVFXOn();
    }
    public void Close()
    {
        transform .gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        SaveAndLoadMusic.Instance.isOn = toggle_switch.isOn;
        SaveAndLoadMusic.Instance.SaveIsSoundOn();
        SaveAndLoadMusic.Instance.vfxCondition = toggle_vfx.vfxCondition;
        SaveAndLoadMusic.Instance.SaveIsVFXOn();
        SoundManager.Instance.PlaySFX("Click");
    }
    public void Back_Home()
    {
        SceneManager.LoadScene("Home_Page");
        SoundManager.Instance.PlaySFX("Click");
    }
    public void Back_Level_List()
    {
        SceneManager.LoadScene("Menu_Page");
        SoundManager.Instance.PlaySFX("Click");
    }
    public void Restart()
    {
        SoundManager.Instance.PlaySFX("Click");
        string nameSceene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nameSceene);
    }
}
