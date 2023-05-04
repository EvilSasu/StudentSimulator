using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameUi;
    public GameObject gun;
    public static bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                ResumeGame();
            }
            else PauseGame();
        }
    }

    private void Awake()
    {
        gun.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        gameUi.SetActive(true);
        //gun.GetComponent<Gun>().enabled = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }

    public void PauseGame()
    {
        gun.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameUi.SetActive(false);
        //gun.GetComponent<Gun>().enabled = false;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }
    public void ResumeGame()
    {
        gun.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        gameUi.SetActive(true);
        //gun.GetComponent<Gun>().enabled = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
