using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public GameScene currentScene;
    public DialoguePanelController dialoguePanel;
    public BackgroundController backgroundController;
    public ChooseController chooseController;

    private State state = State.NORMAL;

    private enum State
    {
        NORMAL, ANIMATE, CHOICE
    }

    private void Start()
    {
        if (currentScene is StoryScene)
        {
            StoryScene storyScene = currentScene as StoryScene;
            if (storyScene.backgroud != null)
                backgroundController.SetImage(storyScene.backgroud);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {

            if (state == State.NORMAL && dialoguePanel.isCompleted())
            {
                if (dialoguePanel.IsLastSentence())
                {
                    //if ((currentScene as StoryScene).nextScene != null)
                    //{
                        PlayScene((currentScene as StoryScene).nextScene);
                    //}
                    //else
                        //this.gameObject.SetActive(false);                  
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
        dialoguePanel.PlayScene((currentScene as StoryScene));
    }

    public void PlayScene(GameScene scene)
    {
        StartCoroutine(SwitchScene(scene));
    }

    private IEnumerator SwitchScene(GameScene scene)
    {
        state = State.ANIMATE;
        currentScene = scene;
        dialoguePanel.HideDialogue();
        yield return new WaitForSeconds(1f);
        if(scene is StoryScene)
        {
            StoryScene storyScene = scene as StoryScene;
            if (storyScene.backgroud != null)
                backgroundController.SwitchImage(storyScene.backgroud);
            yield return new WaitForSeconds(1f);
            dialoguePanel.ClearText();
            dialoguePanel.ShowDialogue();
            yield return new WaitForSeconds(1f);
            dialoguePanel.PlayScene(storyScene);
            state = State.NORMAL;
        }else if(scene is ChooseScene)
        {
            state = State.CHOICE;
            chooseController.SetupChoices(scene as ChooseScene);
        }
        
    }
}
