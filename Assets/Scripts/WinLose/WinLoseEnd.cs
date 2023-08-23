using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseEnd : MonoBehaviour
{
    public BackgroundController gameMaster;
    void Start()
    {
        StartCoroutine(EndDialogue());
    }

    private IEnumerator EndDialogue()
    {
        yield return new WaitForSecondsRealtime(3f);
        gameMaster.PlayFirstDialogue();
    }
}
