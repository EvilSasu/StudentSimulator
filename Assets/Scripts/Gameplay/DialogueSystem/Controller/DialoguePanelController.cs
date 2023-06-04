using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialoguePanelController : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI personNameText;
    public GameObject animationMaster;
    public Image speaker1Image;
    public Image speaker2Image;
    public Animator animator;
    public int sentenceIndex = 0;
    public MainGameEvent gameEvent;
    public AudioController audioController;

    private StoryScene currentScene;
    private float dialogueSpeed = 0.02f;   
    private State state = State.COMPLETED;
    private bool isHidden = false;

    private void Start()
    {
        animator = transform.parent.GetComponent<Animator>();
    }

    private void Awake()
    {
        speaker1Image.gameObject.SetActive(true);
    }

    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        if (dialogueText.color.a == 0)
            ShowDialogue();
        sentenceIndex = 0;
        PlayNextSentence();
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }

    public void PlayNextSentence()
    {
        DoEvent();
        StartCoroutine(TypeText(currentScene.sentences[sentenceIndex].text));
        personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
        personNameText.color = currentScene.sentences[sentenceIndex].speaker.textColor;

        if(currentScene is StoryScene)
        {
            if (currentScene.sentences[sentenceIndex].speaker.speakerName == "Student")
            {
                speaker2Image.gameObject.SetActive(true);
                speaker2Image.sprite = currentScene.sentences[sentenceIndex].speaker.image;
                speaker1Image.gameObject.SetActive(false);
            }
            else
            {
                speaker1Image.gameObject.SetActive(true);
                speaker1Image.sprite = currentScene.sentences[sentenceIndex].speaker.image;
                speaker2Image.gameObject.SetActive(false);
            }
        }      
    }

    public void DoEvent()
    {
        if(currentScene is StoryScene)
        {
            if(currentScene.sentences[sentenceIndex].gameEvent != null)
            {
                if(currentScene.sentences[sentenceIndex].gameEvent is GameEvent)
                {
                    gameEvent = currentScene.sentences[sentenceIndex].gameEvent;
                    (gameEvent as GameEvent).Raise();
                }else
                {
                    gameEvent = currentScene.sentences[sentenceIndex].gameEvent;
                    (gameEvent as IntGameEvent).Raise(currentScene.sentences[sentenceIndex].gameEventValue);
                }
            }         
        }
    }

    public void SkipDialogue()
    {
        StopAllCoroutines();
        dialogueText.text = currentScene.sentences[sentenceIndex].text;
        StopSound();
        state = State.COMPLETED;
    }

    public void ShowDialogue()
    {
        if (isHidden)
        {
            animator.SetTrigger("ShowDialogue");
            isHidden = false;
        }    
    }

    public void HideDialogue()
    {
        if (!isHidden)
        {
            animator.SetTrigger("HideDialogue");
            isHidden = true;
        }      
    }

    public void ClearText()
    {
        this.dialogueText.text = string.Empty;
    }

    public int GetSentenceIndex()
    {
        return sentenceIndex;
    }

    private enum State
    {
        PLAYING, COMPLETED
    }

    private IEnumerator TypeText(string text)
    {
        dialogueText.text = string.Empty;
        state = State.PLAYING;
        int wordIndex = 0;
        

        while (state != State.COMPLETED)
        {
            dialogueText.text += text[wordIndex];

            if (currentScene.sentences[sentenceIndex].speaker.typingSound != null)
                PlaySound(currentScene.sentences[sentenceIndex].speaker.typingSound);

            yield return new WaitForSeconds(dialogueSpeed);

            if(++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                StopSound();
                break;
            }
        }
    }

    private void PlaySound(AudioClip sound)
    {
        audioController.soundSource.clip = sound;
        audioController.soundSource.Play();
        audioController.soundSource.loop = true;
    }

    private void StopSound()
    {
        audioController.soundSource.Stop();
        audioController.soundSource.clip = null;
    }

}
