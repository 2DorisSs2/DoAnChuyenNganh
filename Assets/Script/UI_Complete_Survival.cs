using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Complete_Survival : MonoBehaviour
{
    public Text textScore;
    public Level_Manager_Survival Level;
    public Transform Win_UI;
    public void Update()
    {
        if(Level.endGame)
        {
            Show_UI_Win();
            Level.endGame = false;
        } 
    }
    public void Show_UI_Win()
    {
        Win_UI.gameObject.SetActive(true);
        SetText();
        Time.timeScale = 0f;
    }
    public void SetText()
    {
        textScore.text = "Your Score: " + Level.score.ToString();
    }
    public void Menu_List()
    {
        SceneManager.LoadScene("Survial_Mode_Menu");
    }
    public void Restart()
    {
        string name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);
    }
}
