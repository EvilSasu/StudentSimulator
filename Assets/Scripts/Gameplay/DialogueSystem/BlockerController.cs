using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BlockerController : MonoBehaviour
{
    public void SetBlockerDark()
    {
        this.gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 200);
    }

    public void SetBlockerNormal()
    {
        this.gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
    }
}
