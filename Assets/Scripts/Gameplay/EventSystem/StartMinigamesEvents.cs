using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMinigamesEvents : MonoBehaviour
{
    public LevelLoaderScript LL;
    public PlayerData playerData;
    public PopUpInfoMeneger pop;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("LevelLoader") != null)
            LL = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoaderScript>();
        else
            Debug.Log("No LevelLoader Object!");
    }

    public void StartShopMinigame()
    {
        if (playerData.energy >= 10)
            LL.LoadChoosenLevel(3);
        else
            pop.CreateSpecialPopUp("Za ma³o energii (wymagane 10)");
    }

    public void StartRomaMinigame()
    {
        if (playerData.energy >= 50)
            LL.LoadChoosenLevel(15);
        else
            pop.CreateSpecialPopUp("Za ma³o energii (wymagane 50)");
    }

    public void StartUczelniaMinigame()
    {
        LL.LoadChoosenLevel(2);
    }

    public void StartRoomMinigame()
    {
        if (playerData.energy >= 20)
            LL.LoadChoosenLevel(16);
        else
            pop.CreateSpecialPopUp("Za ma³o energii (wymagane 20)");
    }

    public void StartPiramidyMinigame()
    {
        LL.LoadChoosenLevel(11);
    }
}
