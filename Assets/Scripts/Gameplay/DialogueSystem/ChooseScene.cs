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
        public GameEvent gameEvent;
        public GameEvent gameEventWarunek;
    }
}
