using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public StoryScene currentScene;
    public DialoguePanelController dialoguePanel;
    public BackgroundController backgroundController;

    private State state = State.NORMAL;

    private enum State
    {
        NORMAL, ANIMATE
    }

    private void Start()
    {
        if (currentScene.backgroud != null)
            backgroundController.SetImage(currentScene.backgroud);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            //state == State.NORMAL && 
            if (dialoguePanel.isCompleted())
            {
                if (dialoguePanel.IsLastSentence())
                {
                    if (currentScene.nextScene != null)
                    {
                        /*currentScene = currentScene.nextScene;
                        dialoguePanel.sentenceIndex = 0;
                        dialoguePanel.PlayScene(currentScene);
                        if (currentScene.backgroud != null)
                            backgroundController.SwitchImage(currentScene.backgroud);*/
                        //PlayScene(currentScene.nextScene);
                        currentScene = currentScene.nextScene;
                        dialoguePanel.PlayScene(currentScene);
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

    private void PlayScene(StoryScene scene)
    {
        StartCoroutine(SwitchScene(scene));
    }

    private IEnumerator SwitchScene(StoryScene scene)
    {
        state = State.ANIMATE;
        currentScene = scene;
        dialoguePanel.HideDialogue();
        yield return new WaitForSeconds(1f);
        if(currentScene.backgroud != null)
            backgroundController.SwitchImage(scene.backgroud);
        yield return new WaitForSeconds(1f);
        dialoguePanel.ClearText();
        dialoguePanel.ShowDialogue();
        yield return new WaitForSeconds(1f);
        dialoguePanel.PlayScene(scene);
        state = State.NORMAL;
    }
}
