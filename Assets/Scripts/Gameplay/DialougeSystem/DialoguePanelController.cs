using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialoguePanelController : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI personNameText;
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
