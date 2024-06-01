using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Lv_Manager : Singleton<Data_Lv_Manager>
{
    public Level_Data[] _levelData;
    private int totalNumberOfLevels;
    public Transform tf;
    //public string filePath;
    public UI_Btn UI_Ctrl;

    private void Awake()
    {
        _levelData = SaveAndLoadData.Instance.LoadData();
        Debug.Log(_levelData.Length);
    }

    public void LoadUILevel()
    {
        totalNumberOfLevels = tf.childCount;
        for (int i = 0; i < totalNumberOfLevels; i++)
        {
            UI_Ctrl = tf.GetChild(i).GetComponent<UI_Btn>();
            UI_Ctrl.levelData = _levelData[i];
            UI_Ctrl.SetText(UI_Ctrl.levelData.levelNumber.ToString());
            Debug.Log(UI_Ctrl);
        }
    }
}
