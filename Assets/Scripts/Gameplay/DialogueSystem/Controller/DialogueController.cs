using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueController : MonoBehaviour
{
    public GameScene currentScene;
    public DialoguePanelController dialoguePanel;
    public BackgroundController backgroundController;
    public ChooseController chooseController;
    public GameObject blocker;
    public GameObject mapButton;
    public GameObject phoneButton;
    public GameObject goToRoomButton;
    public GameObject phone;
    public GameObject choiceBlocker;

    public AudioController audioController;

    private State state = State.NORMAL;
    private PlayerData player;
    private enum State
    {
        NORMAL, ANIMATE, CHOICE
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
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
            if (state == State.NORMAL && dialoguePanel.IsCompleted())
            {
                if (dialoguePanel.IsLastSentence())
                {
                    if ((currentScene as StoryScene).nextScene != null)
                    {
                        choiceBlocker.SetActive(false);
                        PlayScene((currentScene as StoryScene).nextScene);
                    }
                    else
                    {
                        blocker.SetActive(false);
                        choiceBlocker.SetActive(false);
                        phoneButton.GetComponent<Button>().interactable = true;
                        mapButton.GetComponent<Button>().interactable = true;

                        gameObject.SetActive(false);
                    }
                                         
                }
                else
                {
                    dialoguePanel.sentenceIndex++;
                    dialoguePanel.PlayNextSentence();
                    PlayAudio((currentScene as StoryScene).sentences[dialoguePanel.GetSentenceIndex()]);
                }
            }
            else if(!dialoguePanel.IsCompleted() && state == State.NORMAL)
                dialoguePanel.SkipDialogue();
        }
        if(currentScene == null && this.gameObject.activeSelf == true)
        {
            blocker.SetActive(false);
            phoneButton.GetComponent<Button>().interactable = true;
            mapButton.GetComponent<Button>().interactable = true;
            goToRoomButton.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    public void PlayDialogue()
    {
        if(currentScene.name != "PrologCz13Aka")
            phone.GetComponent<PhoneController>().HidePhone();

        dialoguePanel.PlayScene((currentScene as StoryScene));
    }

    public void PlayScene(GameScene scene)
    {
        StartCoroutine(SwitchScene(scene));
    }

    private IEnumerator SwitchScene(GameScene scene)
    {
        phoneButton.GetComponent<Button>().interactable = false;
        mapButton.GetComponent<Button>().interactable = false;
 
        state = State.ANIMATE;
        currentScene = scene;
        dialoguePanel.HideDialogue();
        dialoguePanel.sentenceIndex = 0;
        yield return new WaitForSeconds(1f);
        if(scene is StoryScene)
        {
            StoryScene storyScene = scene as StoryScene;
            if (storyScene.backgroud != null)
                backgroundController.SwitchImage(storyScene.backgroud);
            PlayAudio(storyScene.sentences[0]);
            yield return new WaitForSeconds(1f);
            dialoguePanel.ClearText();
            dialoguePanel.ShowDialogue();
            yield return new WaitForSeconds(1f);
            dialoguePanel.PlayScene(storyScene);
            state = State.NORMAL;
        }else if(scene is ChooseScene)
        {
            state = State.CHOICE;
            dialoguePanel.ClearText();
            chooseController.SetupChoices(scene as ChooseScene);
        }
        
    }

    private void PlayAudio(StoryScene.Sentence sentence)
    {
        audioController.PlayAudio(sentence.music, sentence.sound);
    }
}
