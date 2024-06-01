using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveAndLoadData : Singleton<SaveAndLoadData>
{
    public string fileName = "Level_Data";
    //public Level_Data[] levelData;
    public string _text;

    public Level_Data[] LoadData()
    {
        Level_Data[] loadedData = null;
        //Level_Data[] loadDataPre;
          TextAsset textAsset = Resources.Load<TextAsset>(fileName);
          string json_sources = textAsset.text;
          LevelDataContainer container_sources = JsonUtility.FromJson<LevelDataContainer>(json_sources);
          Debug.Log(container_sources);
          loadedData = container_sources.levelData;
          UpdateData(loadedData);
          return loadedData;
    }
    public void UpdateData(Level_Data[] levelData)
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName + ".json");
        LevelDataContainer container = new LevelDataContainer();
        container.levelData = levelData;
        string json = JsonUtility.ToJson(container);
        File.WriteAllText(filePath, json);
    }
}
