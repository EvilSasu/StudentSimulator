using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDataSS
{
    public int money;
    public int energy;
    public int hunger;
    public int wisdom;
    public int mentalHealth;
    public int positionInGameMap;

    public PlayerDataSS(PlayerData p)
    {
        money = p.money;
        energy = p.energy;
        hunger = p.hunger;
        wisdom = p.wisdom;
        mentalHealth = p.mentalHealth;
        positionInGameMap = p.positionInGameMap;
    }
}
