using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class btn_Level_Ctrl : MonoBehaviour
{
    public void Awake()
    {
        addListener();
    }
    public void addListener()
    {
        Button btn_Level = transform.GetComponent<Button>();
        Button.ButtonClickedEvent onClickEvent = new Button.ButtonClickedEvent();
        onClickEvent.AddListener(() => Menu_Ctrl.Instance.LoadLevel(transform.name));
        btn_Level.onClick = onClickEvent;
    }
}
