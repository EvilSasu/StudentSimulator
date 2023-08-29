using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapController : MonoBehaviour
{
    public MapButtonController button;
    public PhoneController phone;
    public GameObject phoneButton;
    private GameObject canvas;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("OutCanvas");
    }

    private void OnDisable()
    {
        button.GetComponent<Button>().interactable = true;
        phoneButton.SetActive(false);
        if (canvas != null)
            canvas.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        phone.HidePhone();
        button.GetComponent<Button>().interactable = false;
        phoneButton.SetActive(true);
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
