using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float distance, time, x;

    private float speed;
    public bool gameStart;

    // Start is called before the first frame update
    void Start()
    {
        gameStart = false;
        speed = distance / time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameStart) return;

        Vector3 tmp = new Vector3(Input.GetAxis("Horizontal") * speed * 2f, 0, speed) * Time.fixedDeltaTime;
        transform.Translate(tmp);
        tmp = transform.position;
        if (tmp.x > x)
            tmp.x = x;
        if (tmp.x < -x)
            tmp.x = -x;
        transform.position = tmp;

    }
}
