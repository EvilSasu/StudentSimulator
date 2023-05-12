using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameDataSS
{
    public int month;
    public int day;
    public int dayOfWeek;

    public int hour;
    public int minute;
    public int second;

    public int sceneIndex;

    public GameDataSS(GameData g)
    {
        month = g.month;
        day = g.day;
        dayOfWeek = g.dayOfWeek;
        hour = g.hour;
        minute = g.minute;
        second = g.second;
        sceneIndex = g.sceneIndex;
    }
}
