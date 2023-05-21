using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SliderValueShowController : MonoBehaviour
{
    public Slider slider;

    private TextMeshProUGUI text;
    private int val;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        val = (int)slider.value;
        text.text = val.ToString();
    }
}
