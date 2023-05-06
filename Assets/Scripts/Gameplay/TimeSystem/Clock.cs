using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Clock : MonoBehaviour
{
    public Calendar calendar;

    public int hours;
    public int minutes;
    public int seconds;

    public void AddHours(int value)
    {
        if ((hours + value) >= 24)
        {
            hours = ((hours + value) % 24);
            calendar.CalculateDay(1);
        }
        hours += value;
    }

    public void AddMinutes(int value)
    {
        if ((minutes + value) >= 60)
        {
            minutes = ((minutes + value) % 60);
            AddHours(1);
        }
        minutes += value;
    }

    public void AddSeconds(int value)
    {
        if((seconds + value) >= 60)
        {
            seconds = ((seconds + value) % 60);
            AddMinutes(1);
        }
        else
            seconds += value;
    }

}