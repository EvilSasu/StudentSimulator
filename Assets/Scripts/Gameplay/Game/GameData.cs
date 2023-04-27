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
            transform.parent.GetComponent<SceneMaster>().dialoguePanel.GetComponent<DialogueController>().backgroundController.PlayFirstDialogue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
