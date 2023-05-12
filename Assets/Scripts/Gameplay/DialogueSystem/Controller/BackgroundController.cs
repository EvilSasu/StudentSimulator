using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackgroundController : MonoBehaviour
{
    public bool isSwitched = false;
    public Image originalSceneBackground;
    public Image background1;
    public Image background2;
    public Animator animator;
    public GameObject gameMaster;
    public StoryScene firstScene;

    //public GameData gameData;
    private void Start()
    {
        ///gameData = GameObject.FindWithTag("GameData").GetComponent<GameData>();
    }

    public void SwitchImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            if(background2 != background1 && background2 != originalSceneBackground)
            {
                background2.sprite = sprite;
                animator.SetTrigger("Switch1");
                isSwitched = !isSwitched;
            }       
        }
        else
        {
            if (background1 != background2 && background1 != originalSceneBackground)
            {
                background1.sprite = sprite;
                animator.SetTrigger("Switch2");
                isSwitched = !isSwitched;
            }           
        }
    }

    public void SetImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            background2.sprite = sprite;
        }
        else
        {
            background1.sprite = sprite;
        }
        
    }

    public void PlayFirstDialogue()
    {
        if(firstScene != null)
            gameMaster.GetComponent<SceneMaster>().StartNewDialogue(firstScene);
    }
}
