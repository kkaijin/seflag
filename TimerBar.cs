using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMaxTime(int time1)
    {
        slider.maxValue = time1;
        slider.value = time1;
    }

    public void SetTime(int time1)
    {
        slider.value = time1;
    }
}
