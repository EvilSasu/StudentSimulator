using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UczelniaRandomEvents : MonoBehaviour
{
    public List<StoryScene> listOfGruszkaScenes;
    public List<StoryScene> listOfKolekScenes;
    public List<StoryScene> listOfRobotScenes;
    public List<StoryScene> listOfZarowaScenes;

    private bool waitEnding = false;
    private PlayerData player;
    private GameData gameData;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
        gameData = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameData>();
        StartCoroutine(StartWait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartWait()
    {
        yield return new WaitForSeconds(1.5f);
        waitEnding = true;
    }
}
