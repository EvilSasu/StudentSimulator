using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderController : MonoBehaviour
{
    public Image fill;
    private Slider slider;
    void Start()
    {
        slider = this.gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name == "HungerSlider")
            CalculateColorHunger();
        else
            CalculateColor();
    }

    void CalculateColor()
    {
        if (slider.value >= 70)
            fill.color = Color.green;
        if (slider.value < 70 && slider.value >= 30)
            fill.color = Color.yellow;
        if (slider.value < 30)
            fill.color = Color.red;
    }

    void CalculateColorHunger()
    {
        if (slider.value >= 70)
            fill.color = Color.red;
        if (slider.value < 70 && slider.value >= 30)
            fill.color = Color.yellow;
        if (slider.value < 30)
            fill.color = Color.green;
    }
}
