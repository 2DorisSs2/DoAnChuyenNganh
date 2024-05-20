using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonState : MonoBehaviour
{
    public bool currentValue;
    
    public void SetButtonValue(bool value)
    {
        currentValue = value;
    }
}
