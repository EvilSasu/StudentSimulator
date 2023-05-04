using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int money;
    public int energy;
    public int hunger;
    public int winsdom;
    public int metalHealth;

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
        if (winsdom >= value)
            return true;
        else
            return false;
    }

    public bool CheckMetalHealthBiggierThan(int value)
    {
        if (metalHealth >= value)
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
    }

    public void IncreaseHunger(int value)
    {
        hunger += value;
    }

    public void IncreaseWinsdom(int value)
    {
        winsdom += value;
    }

    public void IncreaseMetalHealth(int value)
    {
        metalHealth += value;
    }

    public void DecreaseMoney(int value)
    {
        money -= value;
    }

    public void DecreaseEnergy(int value)
    {
        energy -= value;
    }

    public void DecreaseHunger(int value)
    {
        hunger -= value;
    }

    public void DecreaseWinsdom(int value)
    {
        winsdom -= value;
    }

    public void DecreaseMetalHealth(int value)
    {
        metalHealth -= value;
    }

    public int Getmoney()
    {
        return money;
    }

    public void Setmoney(int value)
    {
        money = value;
    }

    public int GetmetalHealth()
    {
        return metalHealth;
    }

    public void SetmetalHealth(int value)
    {
        metalHealth = value;
    }

    public int Getwinsdom()
    {
        return winsdom;
    }

    public void Setwinsdom(int value)
    {
        winsdom = value;
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
