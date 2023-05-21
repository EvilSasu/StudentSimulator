using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapController : MonoBehaviour
{
    public MapButtonController button;
    private GameObject canvas;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("OutCanvas");
    }

    private void OnDisable()
    {
        button.GetComponent<Button>().interactable = true;
        if(canvas != null)
            canvas.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        button.GetComponent<Button>().interactable = false;
        if (canvas != null)
            canvas.gameObject.SetActive(true);
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
