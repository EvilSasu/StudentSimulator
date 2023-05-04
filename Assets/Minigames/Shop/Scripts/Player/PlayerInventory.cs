using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool rKey, gKey, bKey;

    private void Start()
    {
        UiManager.Instance.ClearKeys();
    }
}
