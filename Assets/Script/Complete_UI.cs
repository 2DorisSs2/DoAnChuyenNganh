using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Complete_UI : MonoBehaviour
{
    public Transform Win_UI;
    public Transform Lose_UI;
    public Level_Manager Level_Manager;
    public Transform parent;
    private int count = 0;
    public Transform list_Star;
    private bool DoneCheck = false;
    private int id;
    private string numberSceene;
    private Level_Data[] Level_Data;
    private void Awake()
    {
        numberSceene = GetSceneNumber(SceneManager.GetActiveScene().name);
        id = int.Parse(numberSceene);
        Level_Data = SaveAndLoadData.Instance.LoadData();
    }

    public void Update()
    {
        if(!DoneCheck)
        {
            Check();
        }
        
    }

    public void Check()
    {
        if(Level_Manager.numberquest >= 3)
        {
            for (int i = 0; i < parent.transform.childCount; i++)
            {
                Image image = parent.transform.GetChild(i).GetComponent<Image>();
                if (image != null && !image.gameObject.activeSelf)
                {
                    count++;
                }
            }
            if (count <= 0)
            {
                Show_UI_Lose();
                DoneCheck = true;
            }
            else
            {
                SoundManager.Instance.PlaySFX("Level_Complete");
                Show_UI_Win();
                Debug.Log(count);
                Show_Star(count);
                DoneCheck = true;
            }
        }
    }

    public void Show_UI_Win()
    {
        Win_UI.gameObject.SetActive(true);
        Time.timeScale = 0f;
        SaveData();
    }

    public void Show_UI_Lose()
    {
        Lose_UI.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Show_Star(int i)
    {
        list_Star.transform.GetChild(i-1).gameObject.SetActive(true);
    }

    public string GetSceneNumber(string sceneName)
    {
        int firstNonDigitIndex = 0;
        for (int i = sceneName.Length - 1; i >= 0; i--)
        {
            if (!char.IsDigit(sceneName[i]))
            {
                firstNonDigitIndex = i + 1;
                break;
            }
        }
        return sceneName.Substring(firstNonDigitIndex);
    }

    public void SaveData()
    {
        if (Level_Data[id - 1].isCompleted == false)
        {
            Level_Data[id - 1].isPlaying = false;
            Level_Data[id - 1].isCompleted = true;
        }
        if (Level_Data[id].isCompleted == false)
        {
            Level_Data[id].isPlaying = true;
        }
        Level_Data[id - 1].numberStar = count;
        SaveAndLoadData.Instance.UpdateData(Level_Data);

    }

    public void Next_Stage()
    {
        string level = "Level" + id;
        SceneManager.LoadScene(level);
    }
    public void Menu_List()
    {
        SceneManager.LoadScene("Menu_Page");
    }
    public void Restart()
    {
        string name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);

    }
}
