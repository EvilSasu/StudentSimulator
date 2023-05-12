using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject spawn;
    public bool isFalse;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isFalse) { spawn.SetActive(false); }else
            spawn.SetActive(true);
        }

    }

}
