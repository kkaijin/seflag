using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    int time1 = 15;

    public TimerBar TimeBar;

    public PlayerController playerC;
    public GameObject loseImg;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Timer_count", 1f, 1f);
        TimeBar.SetMaxTime(time1);
    }

    // Update is called once per frame
    void Timer_count()
    {
        time1--;

        TimeBar.SetTime(time1);

        if (time1 <= 0)
        {
            CancelInvoke();
            loseImg.SetActive(true);
        }
        if (playerC.flay >= 1)
        {
            CancelInvoke();
        }
    }
}
