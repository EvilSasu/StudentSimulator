using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameData : MonoBehaviour
{
    public TimeSystem timeSystem;
    public bool firstGameStart = false;
    /// <summary>
    /// Dane do zapisu
    /// </summary>

    public int month;
    public int day;
    public int dayOfWeek;

    public int hour;
    public int minute;
    public int second;

    void Start()
    {
        SetupTime();

        if (SceneManager.GetActiveScene().name == "Prolog")
        {
            transform.parent.GetComponent<SceneMaster>().dialogueSystem.GetComponent<DialogueController>().backgroundController.PlayFirstDialogue();
        }
    }

    private void Update()
    {
        month = timeSystem.calendar.month;
        day = timeSystem.calendar.day;
        dayOfWeek = timeSystem.calendar.dayOfWeek;

        hour = timeSystem.clock.hours;
        minute = timeSystem.clock.minutes;
        second = timeSystem.clock.seconds;
    }

    private void SetupTime()
    {
        timeSystem.calendar.month = month;
        timeSystem.calendar.day = day;
        timeSystem.calendar.dayOfWeek = dayOfWeek;

        timeSystem.clock.hours = hour;
        timeSystem.clock.minutes = minute;
        timeSystem.clock.seconds = second;
    }

}
