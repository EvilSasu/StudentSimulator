using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FridgeController : MonoBehaviour
{
    public Button button;
    public PlayerData playerData;
    public GameObject map;

    public GameObject pizza;
    public GameObject burger;
    public GameObject water;
    public GameObject beer;
    public GameObject bar;

    private void OnEnable()
    {
        button.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        button.gameObject.SetActive(true);

        pizza.gameObject.SetActive(false);
        burger.gameObject.SetActive(false);
        water.gameObject.SetActive(false);
        beer.gameObject.SetActive(false);
        bar.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (map.activeSelf == true)
            this.gameObject.SetActive(false);

        ShowFood();
        CalAmountToShow();
    }

    private void ShowFood()
    {
        if(playerData.amountOfPizza > 0)
            pizza.gameObject.SetActive(true);
        else
            pizza.gameObject.SetActive(false);

        if (playerData.amountOfBurger > 0)
            burger.gameObject.SetActive(true);
        else
            burger.gameObject.SetActive(false);

        if (playerData.amountOfWater > 0)
            water.gameObject.SetActive(true);
        else
            water.gameObject.SetActive(false);

        if (playerData.amountOfBeer > 0)
            beer.gameObject.SetActive(true);
        else
            beer.gameObject.SetActive(false);

        if (playerData.amountOfBar > 0)
            bar.gameObject.SetActive(true);
        else
            bar.gameObject.SetActive(false);
    }

    private void CalAmountToShow()
    {
        if(pizza.gameObject.activeSelf)
            pizza.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.amountOfPizza.ToString();
        if (burger.gameObject.activeSelf)
            burger.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.amountOfBurger.ToString();
        if (water.gameObject.activeSelf)
            water.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.amountOfWater.ToString();
        if (beer.gameObject.activeSelf)
            beer.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.amountOfBeer.ToString();
        if (bar.gameObject.activeSelf)
            bar.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.amountOfBar.ToString();
    }

}
