using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Home_Ctrl : MonoBehaviour
{
    public void Menu_Page()
    {
        string menu = "Menu_Page";
        SceneManager.LoadScene(menu);
    }

}
