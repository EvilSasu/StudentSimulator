using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewStoryScene", menuName = "DialogueSystem/New Story Scene")]
[System.Serializable]
public class StoryScene : ScriptableObject
{
    public List<Sentence> sentences;
    public Sprite backgroud;
    public StoryScene nextScene;
    
    [System.Serializable]
    public struct Sentence
    {
        public string text;
        public Speaker speaker;
        //public AnimationClip animation;
        public string animationTrigger;
    }
}
