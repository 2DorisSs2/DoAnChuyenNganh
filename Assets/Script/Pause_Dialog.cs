using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Dialog : MonoBehaviour
{
    public void Show()
    {
        transform.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Close()
    {
        transform .gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
