using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewChooseScene", menuName = "DialogueSystem/New Choose Scene")]
[System.Serializable]
public class ChooseScene : GameScene
{
    public List<ChooseLabel> labels;

    [System.Serializable]
    public struct ChooseLabel
    {
        public string text;
        public StoryScene nextScene;
        public MainGameEvent gameEvent;
        public MainGameEvent gameEventWarunek;
        public MainGameEvent gameEventWarunek2;
        public int eventValue;
        public int warunekEventValue;
        public int warunekEventValue2;
    }
}
