using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickChangeLevelWitLevelLoader : MonoBehaviour
{
    private LevelLoaderScript LL;
    void Start()
    {
        LL = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoaderScript>();
    }

    // Update is called once per frame
    public void ChangeScene(int i)
    {
        LL.LoadChoosenLevel(i);
    }
}
