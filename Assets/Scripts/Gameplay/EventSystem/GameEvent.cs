using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "GameEvent", menuName = "EventSystem/ Game Event")]
public class GameEvent : ScriptableObject
{
    private readonly List<IGameEventListener> gameEventListeners =
       new List<IGameEventListener>();

    public void Raise()
    {
        for (int i = gameEventListeners.Count - 1; i >= 0; i--)
            gameEventListeners[i].OnEventRaised();
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
