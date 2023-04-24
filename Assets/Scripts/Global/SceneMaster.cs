using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{
    public GameObject dialoguePanel;
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartNewDialogue(StoryScene scene)
    {
        dialoguePanel.SetActive(true);
        dialoguePanel.GetComponent<DialogueController>().currentScene = scene;
        dialoguePanel.GetComponent<DialogueController>().PlayDialogue();
    }
}
