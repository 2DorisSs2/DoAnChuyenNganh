using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Btn : MonoBehaviour
{
    public Level_Data levelData;
    public Image img_Lock;
    public Text text;
    public Button btn_Play;
    public Transform parent;
    private void Awake()
    {
        btn_Play = GetComponent<Button>();
        btn_Play.interactable = false;
    }

    public void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (levelData.isPlaying == true && levelData.isCompleted == false)
        {
            img_Lock.gameObject.SetActive(false);
            btn_Play.interactable = true;
            text.gameObject.SetActive(true);
        }
        else if (levelData.isPlaying == false && levelData.isCompleted == true)
        {
            img_Lock.gameObject.SetActive(false);
            btn_Play.interactable = true;
            text.gameObject.SetActive(true);
        }
        if(levelData.numberStar > 0 && img_Lock.gameObject.activeSelf == false)
        {
            parent.GetChild(levelData.numberStar-1).transform.gameObject.SetActive(true);
        }
        
    }
    public void SetText(string _text)
    {
        text.text = _text;
    }
}
