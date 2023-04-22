using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialoguePanelController : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI personNameText;
    public float dialogueSpeed = 0.05f;
    public Image speaker1Image;
    public Image speaker2Image;

    private StoryScene currentScene;
    public int sentenceIndex = -1;
    private State state = State.COMPLETED;

    public void PlayScene(StoryScene scene)
    {
        sentenceIndex = -1;
        currentScene = scene;
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
        if (sentenceIndex < currentScene.sentences.Count - 1)
        {
            StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
            personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
            personNameText.color = currentScene.sentences[sentenceIndex].speaker.textColor;
        }   
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
        speaker1Image.sprite = currentScene.sentences[sentenceIndex].speaker.image;

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
