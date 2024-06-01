using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Ctrl : Singleton<Menu_Ctrl>
{
    public Transform gridRoot;
    public UnityEngine.UI.Button btn_level;
    public int number_levels = 5;
    // Update is called once per frame
    private void Start()
    {
        Show();
        Data_Lv_Manager.Instance.LoadUILevel();
    }

    public void Show()
    {
        UpdateUI();
        Rename();
    }

    public void UpdateUI()
    {
        clearChirlds();
        if (gridRoot == null) return;
        for(int i = 0;i < number_levels; i++)
        {
            var btn_level_Clone = Instantiate(btn_level, Vector3.zero, Quaternion.identity);
            btn_level_Clone.transform.SetParent(gridRoot);
            btn_level_Clone.transform.localPosition = Vector3.zero;
            btn_level_Clone.transform.localScale = Vector3.one;
        }
    }

    public void Rename()
    {
        if (!gridRoot || gridRoot.childCount <= 0) return;
        for (int i = 0; i < gridRoot.childCount; i++)
        {
            int ID = i + 1;
            var child = gridRoot.GetChild(i);
            if (child)
            {
                child.name = "Level " + ID.ToString();
            }
        }
    }

    public void LoadLevel(string levelID)
    {
        string levelName = levelID;
        SceneManager.LoadScene(levelName);
    }

    public void clearChirlds()
    {
        if (!gridRoot || gridRoot.childCount <= 0) return;
        for (int i = 0; i < gridRoot.childCount; i++)
        {
            var child = gridRoot.GetChild(i);
            if (child)
                Destroy(child.gameObject);
        }
    }

    public void BackHome(string home)
    {
        home = "Home_Page";
        SceneManager.LoadScene(home);
    }
}
