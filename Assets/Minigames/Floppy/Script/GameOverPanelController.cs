using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanelController : MonoBehaviour
{
    public Button restartButton;
    public LevelLoaderScript loader;
    public PlayerData playerData;
    public ScoreManager scoreManager;

    void Start()
    {
        restartButton.onClick.AddListener(NextScene);
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void NextScene()
    {
        //zmiana sceny
        StartCoroutine(EndScene());
    }
    private IEnumerator EndScene()
    {
        int wisdomToAdd = (int) scoreManager.score;
        playerData.IncreaseWinsdom(wisdomToAdd);
        yield return new WaitForSeconds(2f);
        loader.LoadChoosenLevel(9);
    }
}
