using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyButtonController : MonoBehaviour
{
    public SumUpTextInShop sum;
    public PlayerData player;
    public Slider sl1;
    public Slider sl2;
    public Slider sl3;
    public Slider sl4;
    public Slider sl5;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    void Update()
    {
        if (player.money >= sum.finalVal)
        {
            button.interactable = true;
        }
        else
            button.interactable = false;
    }

    public void BuyItems()
    {
        player.AddBar((int)sl1.value);
        player.AddBeer((int)sl2.value);
        player.AddBurger((int)sl3.value);
        player.AddPizza((int)sl4.value);
        player.AddWater((int)sl5.value);

        player.DecreaseMoney(sum.finalVal);
    }
}
