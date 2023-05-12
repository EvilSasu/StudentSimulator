using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{
    public LevelLoaderScript levelLoader;

    [SerializeField] public GameObject playerData;
    [SerializeField] public GameObject gameData;
    public static PlayerData pData;
    public static GameData gData;

    const string PLAYER_SUB = "/save/player";
    const string GAME_SUB = "/save/game";
    const string SAVE_SUB = "/save";

    public bool savesExist;
    int sceneToLoad;
    private void Awake()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0)
            Load();  
    }

    private void OnApplicationQuit()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
            Save();
    }

    private void OnDestroy()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0)
            Save();
    }

    public void Save()
    {
        SavePlayerData();
        SaveGameData();
    }

    public void Load()
    {
        levelLoader = GameObject.FindWithTag("LevelLoader").GetComponent<LevelLoaderScript>();
        CheckIfSavesExist();
        if (savesExist)
        {
            LoadPlayerData();
            LoadGameData();
            if(sceneToLoad != SceneManager.GetActiveScene().buildIndex)
                levelLoader.LoadChoosenLevel(sceneToLoad);
        }     
    }

    public void DeleteSaves()
    {
        string path = Application.persistentDataPath + SAVE_SUB;
        if (Directory.Exists(path)) { Directory.Delete(path, true); }
        Directory.CreateDirectory(path);
    }

    public void CheckIfSavesExist()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + PLAYER_SUB;
        if (File.Exists(path))
        {
            savesExist = true;
        }
        else
            savesExist = false;
        path = Application.persistentDataPath + SAVE_SUB;
        Directory.CreateDirectory(path);
    }

    void SavePlayerData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + PLAYER_SUB;

        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerDataSS data = new PlayerDataSS(pData);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    void SaveGameData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + GAME_SUB;

        FileStream stream = new FileStream(path, FileMode.Create);
        GameDataSS data = new GameDataSS(gData);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    void LoadPlayerData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + PLAYER_SUB;

        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerDataSS data = formatter.Deserialize(stream) as PlayerDataSS;

            stream.Close();

            PlayerData player = playerData.GetComponent<PlayerData>();
            player.money = data.money;
            player.energy = data.energy;
            player.hunger = data.hunger;
            player.wisdom = data.wisdom;
            player.mentalHealth = data.mentalHealth;
            player.positionInGameMap = data.positionInGameMap;

        }
        else
        {
            Debug.LogError("Path not found in " + path);
        }
    }

    void LoadGameData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + GAME_SUB;

        if (File.Exists(path))
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            GameDataSS data = formatter.Deserialize(stream) as GameDataSS;

            stream.Close();

            GameData game = gameData.GetComponent<GameData>();
            game.month = data.month;
            game.day = data.day;
            game.dayOfWeek = data.dayOfWeek;
            game.hour = data.hour;
            game.minute = data.minute;
            game.second = data.second;
            game.sceneIndex = data.sceneIndex;
            sceneToLoad = data.sceneIndex;
        }
        else
        {
            Debug.LogError("Path not found in " + path);
        }
    }
}
