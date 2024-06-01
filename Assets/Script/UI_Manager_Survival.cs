using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager_Survival : MonoBehaviour
{
    public Text scoreText;
    public string Score;
    public Level_Manager_Survival Level;
    private void Update()
    {
        Score = "Your Score: " + Level.score.ToString();
        SetText();
    }
    public void SetText()
    {
        scoreText.text = Score;
    }
}
