using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameEventListener
{
    void OnEventRaised();
    void OnEventRaised(int value);
}
