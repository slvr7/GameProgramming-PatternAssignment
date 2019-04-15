using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServiceSpace;
using UnityEngine.UI;

public class TimeManager : Service
{
    public Text TimeText;
    private float currentTime;
    private float startTime;

    public float GetCurrentTime()
    {
        return currentTime;
    }

    public void  Timing()
    {
        currentTime += Time.time-startTime;
    }

    public void initialize()
    {
        currentTime = 0;
        startTime = 0;
        SetServiceStatus(Status.GameStart);
    }

    public void clearTime()
    {
        currentTime = 0;
        startTime = 0;
        SetServiceStatus(Status.GameOver);
    }

    public void displayTime()
    {
        TimeText.text = "Time :  " + currentTime;
    }

    internal override void Update()
    {
        Timing();
        displayTime();
        SetServiceStatus(Status.GamePlaying);
    }
}
