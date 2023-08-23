using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerData : MonoBehaviour
{
    public int money;
    public int energy;
    public int hunger;
    public int wisdom;
    public int mentalHealth;
    public int positionInGameMap = 0;
    public PopUpInfoMeneger popUpInfoMeneger;

    public int amountOfPizza;
    public int amountOfBurger;
    public int amountOfWater;
    public int amountOfBeer;
    public int amountOfBar;

    private void Awake()
    {
        SaveSystem.pData = this;
    }

    private void Update()
    {
        
    }

    public void SetPositionOnMap(int i)
    {
        positionInGameMap = i;
    }

    public bool CheckMoneyBiggierThan(int value)
    {
        if (money >= value)
            return true;
        else
            return false;
    }

    public bool CheckEnergyBiggierThan(int value)
    {
        if (energy >= value)
            return true;
        else
            return false;
    }

    public bool CheckHungerBiggierThan(int value)
    {
        if (hunger >= value)
            return true;
        else
            return false;
    }

    public bool CheckWinsdomBiggierThan(int value)
    {
        if (wisdom >= value)
            return true;
        else
            return false;
    }

    public bool CheckMentalHealthBiggierThan(int value)
    {
        if (mentalHealth >= value)
            return true;
        else
            return false;
    }

    public void IncreaseMoney(int value)
    {
        money += value;
        popUpInfoMeneger.CreatePopUp("pieniêdzy", value, true);
    }

    public void IncreaseEnergy(int value)
    {
        if ((energy + value) >= 100)
            energy = 100;
        else
            energy += value;
        popUpInfoMeneger.CreatePopUp("energii", value, true);
    }

    public void IncreaseHunger(int value)
    {
        if ((hunger + value) >= 100)
        {
            int val = ((hunger + value) - 100) / 10;
            mentalHealth -= val;
            if(val > 0)
                popUpInfoMeneger.CreateSpecialPopUp("Twoje zdrowie psychinczne spada o " + val + " z powodu g³odu");
            hunger = 100;
        }else
            hunger += value;
        popUpInfoMeneger.CreatePopUp("g³odu", value, true);
    }

    public void IncreaseWinsdom(int value)
    {
        if ((wisdom + value) >= 100)
            wisdom = 100;
        else
            wisdom += value;
        popUpInfoMeneger.CreatePopUp("wiedzy", value, true);
    }

    public void IncreaseMentalHealth(int value)
    {
        if ((mentalHealth + value) >= 100)
            mentalHealth = 100;
        else
            mentalHealth += value;
        popUpInfoMeneger.CreatePopUp("zdrowia psychicznego", value, true);
    }

    public void DecreaseMoney(int value)
    {
        if ((money - value) <= 0)
            money = 0;
        else
            money -= value;
        popUpInfoMeneger.CreatePopUp("pieniêdzy", value, false);
    }

    public void DecreaseEnergy(int value)
    {    
        if ((energy - value) <= 0)
        {
            mentalHealth -= (value / 10);
            energy = 0;
        }
        else
            energy -= value;
        popUpInfoMeneger.CreatePopUp("energii", value, false);
    }

    public void DecreaseHunger(int value)
    {
        if ((hunger - value) <= 0)
            hunger = 0;
        else
            hunger -= value;
        popUpInfoMeneger.CreatePopUp("g³odu", value, false);
    }

    public void DecreaseWinsdom(int value)
    {
        if ((wisdom - value) <= 0)
            wisdom = 0;
        else
            wisdom -= value;
        popUpInfoMeneger.CreatePopUp("wiedzy", value, false);
    }

    public void DecreaseMentalHealth(int value)
    {
        if ((mentalHealth - value) <= 0)
            mentalHealth = 0;
        else
            mentalHealth -= value;
        popUpInfoMeneger.CreatePopUp("zdrowia psychicznego", value, false);
    }

    public int Getmoney()
    {
        return money;
    }

    public void Setmoney(int value)
    {
        money = value;
    }

    public int GetmentalHealth()
    {
        return mentalHealth;
    }

    public void SetmentalHealth(int value)
    {
        mentalHealth = value;
    }

    public int Getwinsdom()
    {
        return wisdom;
    }

    public void Setwinsdom(int value)
    {
        wisdom = value;
    }

    public int Gethunger()
    {
        return hunger;
    }

    public void Sethunger(int value)
    {
        hunger = value;
    }

    public int Getenergy()
    {
        return energy;
    }

    public void Setenergy(int value)
    {
        energy = value;
    }

    public void AddBurger(int value)
    {
        amountOfBurger += value;
    }
    public void AddBar(int value)
    {
        amountOfBar += value;
    }
    public void AddWater(int value)
    {
        amountOfWater += value;
    }
    public void AddBeer(int value)
    {
        amountOfBeer += value;
    }
    public void AddPizza(int value)
    {
        amountOfPizza += value;
    }
    public void RemoveBurger(int value)
    {
        amountOfBurger -= value;
        DecreaseHunger(30 * value);
    }
    public void RemoveBar(int value)
    {
        amountOfBar -= value;
        DecreaseHunger(5 * value);
        IncreaseEnergy(5 * value);
    }
    public void RemoveWater(int value)
    {
        amountOfWater -= value;
        DecreaseHunger(2 * value);
    }
    public void RemoveBeer(int value)
    {
        amountOfBeer -= value;
        DecreaseHunger(3 * value);
        IncreaseEnergy(3 * value);
        IncreaseMentalHealth(3 * value);
    }
    public void RemovePizza(int value)
    {
        amountOfPizza -= value;
        DecreaseHunger(20 * value);
    }
}
