using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Home_Ctrl : MonoBehaviour
{
    public Toggle_Switch_Music_Ctrl toggle_Switch_;
    private void Awake()
    {
        toggle_Switch_.isOn = SaveAndLoadMusic.Instance.isOn;
    }
    public void Menu_Page()
    {
        string menu = "Menu_Page";
        SceneManager.LoadScene(menu);
    }
    public void Menu_Page_Survival()
    {
        string menu = "Survial_Mode_Menu";
        SceneManager.LoadScene(menu);
    }
}
