using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public bool rKey, gKey, bKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (rKey)
            {
                other.GetComponent<PlayerInventory>().rKey = true;
                UiManager.Instance.Keys("RED");
            }
            if (gKey)
            {
                other.GetComponent<PlayerInventory>().gKey = true;
                UiManager.Instance.Keys("GREEN");
            }
            if (bKey)
            {
                other.GetComponent<PlayerInventory>().bKey = true;
                UiManager.Instance.Keys("BLU");
            }

            Destroy(gameObject);
        }
    }
}
