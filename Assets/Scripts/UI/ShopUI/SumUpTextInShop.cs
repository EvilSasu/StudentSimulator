using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SumUpTextInShop : MonoBehaviour
{
    public TextOfItemsValue val1;
    public TextOfItemsValue val2;
    public TextOfItemsValue val3;
    public TextOfItemsValue val4;
    public TextOfItemsValue val5;

    public int finalVal;
    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        finalVal = val1.finalPrice + val2.finalPrice + val3.finalPrice + val4.finalPrice + val5.finalPrice;
        text.text = finalVal.ToString() + " z³";
    }
}
