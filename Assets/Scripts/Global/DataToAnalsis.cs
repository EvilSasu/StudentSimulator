using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataToAnalsis : MonoBehaviour
{
    public GameData gameData;
    public PlayerData playerData;

    private string filePath;
    private string folderPath;
    private string fileName;
    private string delimiter = ",";

    private int timeInSec = 0;
    private bool countStarted = false;
    void Start()
    {
        CheckAndCreateFolderAndFile();
    }

    void Update()
    {
        gameData = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameData>();
        playerData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            if(countStarted == false)
                StartCoroutine(StartCoutingTime());
        }
    }

    public void DeleteFolderWithData()
    {
        if(Directory.Exists(folderPath))
            Directory.Delete(folderPath, true);
    }

    public void CheckAndCreateFolderAndFile()
    {
        // Utwórz œcie¿kê do pliku CSV
        folderPath = Application.dataPath + "/Dane";
        fileName = "AnalsisData" + ".csv";
        filePath = Path.Combine(folderPath, fileName);

        // Utwórz plik CSV, jeœli jeszcze nie istnieje
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);
        
        if (!File.Exists(filePath))
        {
            Debug.Log("Creating file");
            File.WriteAllText(filePath, "Month" + delimiter + "Day" + delimiter + "GameTime"
                + delimiter + "Money" + delimiter + "Energy" + delimiter
                + "Hunger" + delimiter + "Wisdom" + delimiter + "MentalHealth" + "\n");
        }
    }

    public void AddEnter()
    {
        string line = "\n";
        File.AppendAllText(filePath, line);
    }

    private IEnumerator StartCoutingTime()
    {
        countStarted = true;

        while (timeInSec <= 60)
        {
            timeInSec += 1;
            yield return new WaitForSecondsRealtime(1f);
        }

        WriteCSV();
        timeInSec = 0;
        countStarted = false;
    }

    private void WriteCSV()
    {
        // Dodaj dane do pliku CSV
        Debug.Log("Saved");

        int gameTimeInMinutes = (gameData.playingTime / 60);

        string line = gameData.month.ToString() + delimiter + gameData.day.ToString() + delimiter +
                        gameTimeInMinutes.ToString() + delimiter + playerData.money.ToString() +
                        delimiter + playerData.energy.ToString() + delimiter + playerData.hunger.ToString() +
                        delimiter + playerData.wisdom.ToString() + delimiter + playerData.mentalHealth.ToString() + "\n";

        File.AppendAllText(filePath, line);
    }
}
