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
    }

    public void IncreaseEnergy(int value)
    {
        energy += value;
        if ((energy + value) >= 100)
            energy = 100;
    }

    public void IncreaseHunger(int value)
    {
        hunger += value;
        if ((hunger + value) >= 100)
        {
            mentalHealth -= ((hunger + value) - 100) / 10;
            hunger = 100;
        }
    }

    public void IncreaseWinsdom(int value)
    {
        wisdom += value;
        if ((wisdom + value) >= 100)
            wisdom = 100;
    }

    public void IncreaseMentalHealth(int value)
    {
        mentalHealth += value;
        if ((mentalHealth + value) >= 100)
            mentalHealth = 100;
    }

    public void DecreaseMoney(int value)
    {
        money -= value;
        if ((money - value) <= 0)
            money = 0;
    }

    public void DecreaseEnergy(int value)
    {
        energy -= value;
        if ((energy - value) <= 0)
        {
            mentalHealth -= (value / 10);
            energy = 0;
        }         
    }

    public void DecreaseHunger(int value)
    {
        hunger -= value;
        if ((hunger - value) <= 0)
            hunger = 0;
    }

    public void DecreaseWinsdom(int value)
    {
        wisdom -= value;
        if ((wisdom - value) <= 0)
            wisdom = 0;
    }

    public void DecreaseMentalHealth(int value)
    {
        mentalHealth -= value;
        if ((mentalHealth - value) <= 0)
            mentalHealth = 0;
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

}
