using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Controller : MonoBehaviour
{
    public Button yourButton;
    public bool buttonValue = false; // Giá trị của button
    public ButtonState buttonState;
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        buttonState.SetButtonValue(buttonValue);
        if (!buttonValue)
        {
            Level_Manager.Instance.speed += 0.75f;
            SoundManager.Instance.PlaySFX("False");
        }
    }
}
