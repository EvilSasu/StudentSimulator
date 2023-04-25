using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackgroundController : MonoBehaviour
{
    public bool isSwitched = false;
    public Image background;
    public Animator animator;

    private void Start()
    {
        SwitchImage(background.sprite);
    }

    public void SwitchImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            background.sprite = sprite;
            animator.SetTrigger("Switch");
        }
        isSwitched = !isSwitched;
    }

    public void SetImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            background.sprite = sprite;
        }
    }
}
