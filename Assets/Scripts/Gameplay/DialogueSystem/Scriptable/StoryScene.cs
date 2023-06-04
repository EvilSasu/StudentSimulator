using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewStoryScene", menuName = "DialogueSystem/New Story Scene")]
[System.Serializable]
public class StoryScene : GameScene
{
    public List<Sentence> sentences;
    public Sprite backgroud;
    //public StoryScene nextScene;
    public GameScene nextScene;

    [System.Serializable]
    public struct Sentence
    {
        public string text;
        public Speaker speaker;
        public MainGameEvent gameEvent;
        public int gameEventValue;

        public AudioClip music;
        public AudioClip sound;
    }
}

public class GameScene : ScriptableObject
{

}
