using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SleepPanelController : MonoBehaviour
{
    public Slider slider;
    public Clock clock;
    public LevelLoaderScript levelLoader;

    public void Sleep()
    {
        int val = (int)slider.value;
        clock.GoToSleep(val);
        levelLoader.LoadChoosenLevel(SceneManager.GetActiveScene().buildIndex);
        this.gameObject.SetActive(false);
    }
}
