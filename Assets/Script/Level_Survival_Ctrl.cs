using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_Survival_Ctrl : MonoBehaviour
{
    public void Back_Home()
    {
        SceneManager.LoadScene("Home_Page");
    }
    public void LoadSceene(string nameSceene)
    {
        SceneManager.LoadScene(nameSceene); 
    }
}
