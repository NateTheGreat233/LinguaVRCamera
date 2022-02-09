using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// getting current times
public class TimeStamps : MonoBehaviour
{
    private DateTime currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = DateTime.Now;
    }

    public TimeSpan GetCurrentTime()
    {
        return currentTime.TimeOfDay;
    }

    public int CurrentYear()
    {
        return currentTime.Year;
    }
    public int CurrentMonth()
    {
        return currentTime.Month;
    }
    public int CurrentDay()
    {
        return currentTime.Day;
    }
    public int CurrentHour()
    {
        return currentTime.Hour;
    }

    public int CurrentMin()
    {
        return currentTime.Minute;
    }

    public int CurrentSec()
    {
        return currentTime.Second;
    }

}
