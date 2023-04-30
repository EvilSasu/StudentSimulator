using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public void SetAct()
    {
        this.gameObject.SetActive(true);
    }

    public void SetDisAct()
    {
        this.gameObject.SetActive(false);
    }
}
