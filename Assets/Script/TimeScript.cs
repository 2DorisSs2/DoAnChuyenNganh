using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public Slider slider_timer;
    public float time = 13;
    public bool endtime = false;
    public float _time = 13;
    // Start is called before the first frame update
    void Start()
    {
        slider_timer.maxValue = time;
        slider_timer.value = time;
        StartTime();
    }
    
    public void StartTime()
    {
        StartCoroutine(StartTheTime());
    }
    IEnumerator StartTheTime()
    {
        //Debug.Log(slider_timer.maxValue);
        while (endtime == false)
        {
            _time -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);
            if (time < 0)
            {
                endtime = true;
            }
            if (endtime == false)
            {
                slider_timer.value = _time;
            }
        }
    }
}
