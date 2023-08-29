using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UczelniaDoorToStartController : MonoBehaviour
{
    public GameData gameData;
    public LevelLoaderScript loader;
    public PlayerData player;
    public PopUpInfoMeneger pop;

    public void UseDoor()
    {
        if ((gameData.hour >= 8 && gameData.hour <= 16) && (gameData.dayOfWeek >= 0 && gameData.dayOfWeek <= 4))
        {
            if(player.energy >= 20)
                loader.LoadChoosenLevel(10);
            else
                pop.CreateSpecialPopUp("Jeste� zbyt zm�czony!");
        }
        else
            pop.CreateSpecialPopUp("Zaj�cia odbywaj� si� 8:00 - 16:00 w Poniedzia�ek - pi�tek");
    }
}
