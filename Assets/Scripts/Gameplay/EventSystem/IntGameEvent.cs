using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntGameEvent", menuName = "EventSystem/Int Game Event")]
public class IntGameEvent : ScriptableObject
{
    private readonly List<IGameEventListener> gameEventListeners =
       new List<IGameEventListener>();

    public void Raise(int value)
    {
        for (int i = gameEventListeners.Count - 1; i >= 0; i--)
            gameEventListeners[i].OnEventRaised(value);
    }

    public void RegisterListener(IGameEventListener listener)
    {
        if (!gameEventListeners.Contains(listener))
            gameEventListeners.Add(listener);
    }

    public void UnregisterListener(IGameEventListener listener)
    {
        if (gameEventListeners.Contains(listener))
            gameEventListeners.Remove(listener);
    }
}
