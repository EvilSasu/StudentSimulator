using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public bool Key;
    public bool rKey, gKey, bKey;

    public bool prolog = false;
    public LevelLoaderScript loader;
    public GameObject spawn;
    //public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (Key)
            {
                //wymagany klucz
                if (rKey && other.GetComponent<PlayerInventory>().rKey && gKey && other.GetComponent<PlayerInventory>().gKey && bKey && other.GetComponent<PlayerInventory>().bKey)
                {

                    if (prolog == true)
                    {
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        loader.LoadChoosenLevel(4);
                    }
                    if (prolog == false)
                    {
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        loader.LoadChoosenLevel(2);
                    }


                    //spawn.SetActive(true);
                    //nastêpny poziom
                    //Scene sceneToLoad = SceneManager.GetSceneByName("ztestWorld");
                    //SceneManager.LoadScene(sceneToLoad.name, LoadSceneMode.Additive);
                    //SceneManager.MoveGameObjectToScene(transform.gameObject, sceneToLoad);
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //SceneManager.GetActiveScene().buildIndex + 1
                }
            }

        }

    }
}
