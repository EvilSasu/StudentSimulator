using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour
{

    public GameObject current;
    public GameObject back;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            current.SetActive(false);
            back.SetActive(true);
        }
    }
}
