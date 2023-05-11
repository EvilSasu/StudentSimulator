using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Clock : MonoBehaviour
{
    public Calendar calendar;
    public PlayerData player;

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
        else
            hours += value;
    }

    public void AddMinutes(int value)
    {
        CalculateStatusLost(value);
        if ((minutes + value) >= 60)
        {
            int hoursToAdd = (minutes + value) / 60;
            minutes = ((minutes + value) % 60);
            AddHours(hoursToAdd);
        }
        else
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

    private void CalculateStatusLost(int val)
    {
        int lostMulty = val / 15;
        player.DecreaseEnergy(2 * lostMulty);
        player.IncreaseHunger(2 * lostMulty);
    }
}
