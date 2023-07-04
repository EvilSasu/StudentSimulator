using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float distance, time, speed, x;
    public bool gameStart;

    // Start is called before the first frame update
    void Start()
    {
        speed = distance / time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 tmp = new Vector3();
    }
}
