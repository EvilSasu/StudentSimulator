using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour
{
    [SerializeField]
    private float distance, time;

    private float speed, startSpeed, acceleration;
    public bool gameStart;

    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;

        startSpeed = 2 * distance / time;
        acceleration = -2f * startSpeed / time;
        speed = startSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!gameStart) return;

        speed += acceleration * Time.fixedDeltaTime;
        Vector3 tmp = new Vector3(0, speed * Time.fixedDeltaTime, 0);
        transform.localPosition += tmp;
        tmp = transform.localPosition;

        if (tmp.y < 0f)
        {
            speed = startSpeed;
        }
    }
}
