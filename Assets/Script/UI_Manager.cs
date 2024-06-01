using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public Text text_lv;
    private string currentNameSceene;
    private void Awake()
    {
        currentNameSceene = SceneManager.GetActiveScene().name;
        SetText();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(currentNameSceene);
        Time.timeScale = 1.0f;
    }
    public void SetText()
    {
        text_lv.text = currentNameSceene;
    }
}
