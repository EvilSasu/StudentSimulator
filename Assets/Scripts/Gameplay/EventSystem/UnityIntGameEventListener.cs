using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class UnityIntGameEventListener : MonoBehaviour, IGameEventListener
{
    [SerializeField]
    private IntGameEvent @intEvent;

    [SerializeField]
    private UnityEvent<int> intResponse;

    public void OnEnable()
    {
        if (@intEvent != null)
            @intEvent.RegisterListener(this);
    }

    public void OnDisable()
    {
        if (@intEvent != null)
            @intEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        
    }

    public void OnEventRaised(int value)
    {
        Debug.Log("Jestem w raised i val = " + value);
        intResponse?.Invoke(value);
    }
}
