using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadMusic : Singleton<SaveAndLoadMusic>
{
    public bool isOn = true;
    public bool vfxCondition = true;
    public const string isOnKey = "IsSoundOn";
    public const string isOnVFX = "IsVFXOn";
    public void SaveIsSoundOn()
    {
        PlayerPrefs.SetInt(isOnKey, isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public bool LoadIsSoundOn()
    {
        return PlayerPrefs.GetInt(isOnKey, 0) == 1;
    }

    public void SaveIsVFXOn()
    {
        PlayerPrefs.SetInt(isOnVFX, vfxCondition ? 1 : 0);
        PlayerPrefs.Save();
    }

    public bool LoadIsVFXOn()
    {
        return PlayerPrefs.GetInt(isOnVFX, 0) == 1;
    }
}
