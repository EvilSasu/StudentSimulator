using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Animator doorAnim;
    public bool Key;
    public bool rKey, gKey, bKey;
    public bool nextLvl;

    public GameObject spawn;
    //public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (Key)
            {
                //wymagany klucz
                if (rKey && other.GetComponent<PlayerInventory>().rKey)
                {
                    //otwieranie drzwi
                    doorAnim.SetTrigger("Open_Door");
                    //spawnowanie przeciwników
                    spawn.SetActive(true);
                }
                if (gKey && other.GetComponent<PlayerInventory>().gKey)
                {
                    //otwieranie drzwi
                    doorAnim.SetTrigger("Open_Door");
                    //spawnowanie przeciwników
                    spawn.SetActive(true);
                }
                if (bKey && other.GetComponent<PlayerInventory>().bKey)
                {
                    //otwieranie drzwi
                    doorAnim.SetTrigger("Open_Door");
                    //spawnowanie przeciwników
                    spawn.SetActive(true);
                }
                if (nextLvl)
                {
                    //otwieranie drzwi
                    doorAnim.SetTrigger("Open_Door");
                    //nastêpny poziom
                    //Scene sceneToLoad = SceneManager.GetSceneByName("ztestWorld");
                    //SceneManager.LoadScene(sceneToLoad.name, LoadSceneMode.Additive);
                    //SceneManager.MoveGameObjectToScene(transform.gameObject, sceneToLoad);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //SceneManager.GetActiveScene().buildIndex + 1
                }
            }
            else
            {
                //otwieranie drzwi
                doorAnim.SetTrigger("Open_Door");
                //door.GetComponent<BoxCollider>().transform.position = opendoor;
                //spawnowanie przeciwników
                spawn.SetActive(true);
            }

        }

    }
}
