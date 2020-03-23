using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{
    private Text clock;
    private float time = 0;
    private int wholeTime;
    private int dayCount = 1;

    void Start()
    {
        clock = GetComponent<Text>();
    }

    void Update()
    {
        time += 0.2f * Time.deltaTime;
        wholeTime = Mathf.RoundToInt(time);

        if (wholeTime == 24)
        {
            time = 0;
            dayCount++;
        }
        if (wholeTime < 10)
        {
            clock.text = "Day " + dayCount + "     " + "0" + wholeTime.ToString() + ":00";
        }
        else
        {
            clock.text = "Day " + dayCount + "     " + wholeTime.ToString() + ":00";
        }
    }
}
