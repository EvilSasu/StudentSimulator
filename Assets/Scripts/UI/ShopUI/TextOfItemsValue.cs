using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextOfItemsValue : MonoBehaviour
{
    public Slider slider;
    public int costOfItem;

    private int valueOfLider;
    private TextMeshProUGUI text;
    public int finalPrice;
    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        valueOfLider = (int) slider.value;
        finalPrice = valueOfLider * costOfItem;
        text.text = finalPrice.ToString() + " z³";
    }
}
