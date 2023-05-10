using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapController : MonoBehaviour
{
    public MapButtonController button;
    private void OnDisable()
    {
        button.GetComponent<Button>().interactable = true;
    }
    private void OnEnable()
    {
        button.GetComponent<Button>().interactable = false;
    }

    public void SetAct()
    {
        this.gameObject.SetActive(true);
    }

    public void SetDisAct()
    {
        this.gameObject.SetActive(false);
    }
}
