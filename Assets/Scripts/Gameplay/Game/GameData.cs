using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameData : MonoBehaviour
{
    public bool firstGameStart = false;
    
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Prolog")
        {
            transform.parent.GetComponent<SceneMaster>().dialogueSystem.GetComponent<DialogueController>().backgroundController.PlayFirstDialogue();
        }
    }

}
