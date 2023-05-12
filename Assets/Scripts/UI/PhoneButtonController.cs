using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PhoneButtonController : MonoBehaviour
{

    public void SetUninteracable()
    {
        GetComponent<Button>().interactable = false;
    }

    public void SetInteracable()
    {
        GetComponent<Button>().interactable = true;
    }
}
