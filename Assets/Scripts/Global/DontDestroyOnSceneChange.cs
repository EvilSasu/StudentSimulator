using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnSceneChange : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
