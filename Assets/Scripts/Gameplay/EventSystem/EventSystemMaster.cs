using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemMaster : MonoBehaviour
{
    [SerializeField]
    public List<UnityGameEventListener> unityGameEventListeners;
}
