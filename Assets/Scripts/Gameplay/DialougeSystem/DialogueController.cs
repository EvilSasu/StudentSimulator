using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public StoryScene currentScene;
    public DialoguePanelController dialoguePanel;

    void Start()
    {
        dialoguePanel.PlayScene(currentScene);
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (dialoguePanel.isCompleted())
            {
                if (dialoguePanel.IsLastSentence())
                {
                    /*if (currentScene.nextScene == null)
                        dialoguePanel.gameObject.SetActive(false);
                    else
                    {
                        currentScene = currentScene.nextScene;
                        dialoguePanel.PlayScene(currentScene);
                    }*/
                    currentScene = currentScene.nextScene;
                    dialoguePanel.PlayScene(currentScene);
                }
                dialoguePanel.PlayNextSentence();
            }
        }
    }
}
