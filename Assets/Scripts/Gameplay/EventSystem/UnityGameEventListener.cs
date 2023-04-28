using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityGameEventListener : MonoBehaviour, IGameEventListener
{
    [SerializeField]
    private GameEvent @event;

    [SerializeField]
    private List<GameEvent> @events;

    [SerializeField]
    private UnityEvent response;

    public void OnEnable()
    {
        if (@event != null)
            @event.RegisterListener(this);
    }

    public void OnDisable()
    {
        @event.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        response?.Invoke();
    }
}
