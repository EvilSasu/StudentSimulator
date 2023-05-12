using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{
    public GameObject dialogueSystem;
    public GameObject blocker;

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
        dialogueSystem.SetActive(true);
        blocker.SetActive(true);
        dialogueSystem.GetComponent<DialogueController>().chooseController.gameObject.SetActive(true);
        dialogueSystem.GetComponent<DialogueController>().currentScene = scene;
        dialogueSystem.GetComponent<DialogueController>().PlayDialogue();
    }

}
