using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    private Animation anima;
    public Animator animator;

    public void PlayAnimat(AnimationClip ac)
    {
        anima.clip = ac;
        anima.Play();
    }

    public void UseTrigger(string trigger)
    {
        animator.SetTrigger(trigger);
    }
}
