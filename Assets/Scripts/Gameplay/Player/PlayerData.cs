using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private int money;
    private int energy;
    private int hunger;
    private int winsdom;
    private int metalHealth;

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
        money += value;
    }

    public void IncreaseWinsdom(int value)
    {
        money += value;
    }

    public void IncreaseMetalHealth(int value)
    {
        money += value;
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
        money -= value;
    }

    public void DecreaseWinsdom(int value)
    {
        money -= value;
    }

    public void DecreaseMetalHealth(int value)
    {
        money -= value;
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
