using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FridgeController : MonoBehaviour
{
    public Button button;
    public GameObject map;

    private void OnEnable()
    {
        button.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        button.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (map.activeSelf == true)
            this.gameObject.SetActive(false);
    }
}
