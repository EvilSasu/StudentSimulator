using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UczelniaRandomEvents : MonoBehaviour
{
    public List<StoryScene> listOfGruszkaScenes;
    public List<StoryScene> listOfKolekScenes;
    public List<StoryScene> listOfRobotScenes;
    public List<StoryScene> listOfZarowaScenes;
    public List<StoryScene> listOfGargScenes;

    private bool waitEnding = false;
    private bool eventStarted = false;
    private PlayerData player;
    private GameData gameData;
    private BackgroundController gameMaster;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
        gameData = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameData>();
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<BackgroundController>();
        if (!waitEnding)
            StartCoroutine(StartWait());
    }

    void Update()
    {
        if (waitEnding == true && eventStarted == false)
        {
            ChooseListOfRandomEvents();
        }
    }

    private void ChooseListOfRandomEvents()
    {
        eventStarted = true;

        if (gameData.dayOfWeek == 0)
            ChooseEvent(listOfGruszkaScenes);
        if (gameData.dayOfWeek == 1)
            ChooseEvent(listOfKolekScenes);
        if (gameData.dayOfWeek == 2)
            ChooseEvent(listOfRobotScenes);
        if (gameData.dayOfWeek == 3)
            ChooseEvent(listOfZarowaScenes);
        if (gameData.dayOfWeek == 4)
            ChooseEvent(listOfGargScenes);
    }

    private void ChooseEvent(List<StoryScene> list)
    {
        int choice = Random.Range(0, list.Count);
        gameMaster.firstScene = list[choice];
        gameMaster.PlayFirstDialogue();
    }

    IEnumerator StartWait()
    {
        yield return new WaitForSeconds(1.5f);
        waitEnding = true;
    }
}
