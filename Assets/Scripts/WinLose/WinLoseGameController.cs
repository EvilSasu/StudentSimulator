using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseGameController : MonoBehaviour
{
    public PlayerData player;
    private LevelLoaderScript LL;

    private void Awake()
    {
        LL = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoaderScript>();
    }

    void Update()
    {
        if (player.wisdom >= 99)
            LL.LoadChoosenLevel(18);
        if (player.mentalHealth <= 0)
            LL.LoadChoosenLevel(19);
    }
}
