using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMinigamesEvents : MonoBehaviour
{
    public LevelLoaderScript LL;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("LevelLoader") != null)
            LL = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoaderScript>();
        else
            Debug.Log("No LevelLoader Object!");
    }

    public void StartShopMinigame()
    {
        LL.LoadChoosenLevel(3);
    }

    public void StartRomaMinigame()
    {
        //LL.LoadChoosenLevel(3);
    }

    public void StartUczelniaMinigame()
    {
        LL.LoadChoosenLevel(2);
    }

    public void StartRoomMinigame()
    {
        LL.LoadChoosenLevel(11);
    }
}
