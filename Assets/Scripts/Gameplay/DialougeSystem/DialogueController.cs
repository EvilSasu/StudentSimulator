using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public StoryScene currentScene;
    public DialoguePanelController dialoguePanel;
    public BackgroundController backgroundController;

    private void Start()
    {
        if (currentScene.backgroud != null)
            backgroundController.SetImage(currentScene.backgroud);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
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
                        if (currentScene.backgroud != null)
                            backgroundController.SwitchImage(currentScene.backgroud);
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
            else
                dialoguePanel.SkipDialogue();
        }
    }

    public void PlayDialogue()
    {
        dialoguePanel.PlayScene(currentScene);
    }
}
