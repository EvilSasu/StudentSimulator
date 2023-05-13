using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Calendar : MonoBehaviour
{
    public int month = 10;
    public int day = 1;
    public int dayOfWeek = 0;
    public string dayOfWeekName;

    private string[] nameOfDay = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

    private void Start()
    {
        dayOfWeekName = nameOfDay[dayOfWeek]; 
    }

    private void Update()
    {
        if(dayOfWeekName != nameOfDay[dayOfWeek])
            dayOfWeekName = nameOfDay[dayOfWeek];
    }

    public void CalculateMonth(int val)
    {
        if ((month + val) > 12)
        {
            month = 1;
        }
        else
            month++;
    }

    public void CalculateDay(int val)
    {
        CalculateDayOfWeek();
        if (month == 2)
        {
            if ((day + val) > 28)
            {
                day = 1;
                CalculateMonth(1);
            }
            else
                day++;
            return;
        }
        else if (month % 2 == 0 && month != 2)
        {
            if((day + val) > 31)
            {
                day = 1;
                CalculateMonth(1);
            }
            else
                day++;
            return;
        }
        else if(month % 2 == 1)
        {
            if ((day + val) > 30)
            {
                day = 1;
                CalculateMonth(1);
            }
            else
                day++;
            return;
        }
    }

    public int GetMonth()
    {
        return month;
    }

    public int GetDay()
    {
        return day;
    }

    private void CalculateDayOfWeek()
    {
        if (dayOfWeek >= 6)
            dayOfWeek = 0;
        else
            dayOfWeek++;

        dayOfWeekName = nameOfDay[dayOfWeek];
    }
}
