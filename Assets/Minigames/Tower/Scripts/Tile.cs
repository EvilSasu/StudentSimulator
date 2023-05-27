using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    float distance;
    float maxDistance;
    float lenght;
    bool moveF;
    bool moveX;


    // Start is called before the first frame update
    void Start()
    {
        maxDistance = 5f;
        distance = maxDistance;
        moveF = true;
        if (moveX)
        {
            transform.Translate(distance, 0, 0);
        }
        else transform.Translate(0, 0, distance);

    }

    // Update is called once per frame
    void Update()
    {
        lenght = Time.deltaTime * 6f;
        if (moveX)
        {
            MoveX();
        }
        else MoveZ();
    }

    void MoveX()
    {
        if (moveF)
        {
            if (distance < maxDistance)
            {
                transform.Translate(lenght, 0, 0);
                distance += lenght;
            }
            else
            {
                moveF = false;
            }
        }
        else
        {
            if (distance > -maxDistance)
            {
                transform.Translate(-lenght, 0, 0);
                distance -= lenght;
            }
            else
            {
                moveF = true;
            }
        }
    }

    void MoveZ()
    {
        if (moveF)
        {
            if (distance < maxDistance)
            {
                transform.Translate(0, 0, lenght);
                distance += lenght;
            }
            else
            {
                moveF = false;
            }
        }
        else
        {
            if (distance > -maxDistance)
            {
                transform.Translate(0, 0, -lenght);
                distance -= lenght;
            }
            else
            {
                moveF = true;
            }
        }
    }
}
