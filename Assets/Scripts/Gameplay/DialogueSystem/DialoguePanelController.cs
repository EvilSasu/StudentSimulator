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
    private float dialogueSpeed = 0.02f;
    public Image speaker1Image;
    public Image speaker2Image;

    private StoryScene currentScene;
    public int sentenceIndex = 0;
    private State state = State.COMPLETED;

    private void Awake()
    {
        speaker1Image.gameObject.SetActive(true);
    }

    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        sentenceIndex = 0;
        PlayNextSentence();
    }

    public bool isCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }

    public void PlayNextSentence()
    {
        PlayAnimation();
        StartCoroutine(TypeText(currentScene.sentences[sentenceIndex].text));
        personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
        personNameText.color = currentScene.sentences[sentenceIndex].speaker.textColor;
        if(currentScene.sentences[sentenceIndex].speaker.speakerName == "Student")
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

    public void SkipDialogue()
    {
        StopAllCoroutines();
        dialogueText.text = currentScene.sentences[sentenceIndex].text;
        state = State.COMPLETED;
    }

    private enum State
    {
        PLAYING, COMPLETED
    }

    private void PlayAnimation()
    {
        /*if (currentScene.sentences[sentenceIndex].animation != null)
            animationMaster.GetComponent<PlayAnimation>().PlayAnimat(currentScene.sentences[sentenceIndex].animation);*/
        /*if (currentScene.sentences[sentenceIndex].animationTrigger != null)
        {
            animationMaster.GetComponent<PlayAnimation>().UseTrigger(currentScene.sentences[sentenceIndex].animationTrigger);
            Debug.Log(currentScene.sentences[sentenceIndex].animationTrigger);
        }*/
        if (currentScene.sentences[sentenceIndex].animationTrigger != "")
        {
            animationMaster.GetComponent<BackgroundController>().SwitchImage(animationMaster.GetComponent<BackgroundController>().background.sprite);
        }

    }

    private IEnumerator TypeText(string text)
    {
        dialogueText.text = string.Empty;
        state = State.PLAYING;
        int wordIndex = 0;
        

        while (state != State.COMPLETED)
        {
            dialogueText.text += text[wordIndex];
            yield return new WaitForSeconds(dialogueSpeed);

            if(++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }
}
