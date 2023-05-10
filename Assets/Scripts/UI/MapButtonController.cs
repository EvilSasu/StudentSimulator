using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapButtonController : MonoBehaviour
{
    public bool isShown = false;
    void Update()
    {
        if (GetComponent<Button>().colors.normalColor.a == 0)
            GetComponent<Button>().interactable = false;
        else
            GetComponent<Button>().interactable = true;
    }

    public void ShowOrHide()
    {
        if (isShown == false)
            GetComponent<Animator>().SetTrigger("ShowMapButton");
        else
            GetComponent<Animator>().SetTrigger("HideMapButton");
        isShown = !isShown;
    }

    public void SetUninteracable()
    {
        GetComponent<Button>().interactable = false;
    }
}
