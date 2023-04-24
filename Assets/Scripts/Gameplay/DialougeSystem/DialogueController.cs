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
                    if (currentScene.nextScene != null)
                    {
                        currentScene = currentScene.nextScene;
                        dialoguePanel.sentenceIndex = 0;
                        dialoguePanel.PlayScene(currentScene);
                    }
                    else
                        this.gameObject.SetActive(false);                  
                }
                else
                {
                    dialoguePanel.sentenceIndex++;
                    dialoguePanel.PlayNextSentence();
                }
            }
        }
    }
}
