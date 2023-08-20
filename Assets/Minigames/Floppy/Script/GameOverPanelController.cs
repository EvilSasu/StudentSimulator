using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanelController : MonoBehaviour
{
    public Button restartButton;
    public LevelLoaderScript loader;

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

    void NextScene()
    {
        //zmiana sceny
        loader.LoadChoosenLevel(10);
    }
}
