using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeSystem : MonoBehaviour
{
    public TextMeshProUGUI clockText;
    public TextMeshProUGUI calendarText;

    public Clock clock;
    public Calendar calendar;

    private bool timeRunning = false;

    private void Update()
    {
        clock.AddHours(1);
        if (timeRunning == false)
            StartCoroutine(TimeTicking());
        PrintTimeAndCalendar();
    }

    IEnumerator TimeTicking()
    {
        timeRunning = true;
        clock.AddSeconds(1);
        yield return new WaitForSeconds(1f);
        timeRunning = false;
    }

    private string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }

    private void PrintTimeAndCalendar()
    {
        clockText.text = LeadingZero(clock.hours) + ":" +
            LeadingZero(clock.minutes) + ":" + LeadingZero(clock.secondes);

        calendarText.text = LeadingZero(calendar.day) + "/" + LeadingZero(calendar.month);
    }
}
