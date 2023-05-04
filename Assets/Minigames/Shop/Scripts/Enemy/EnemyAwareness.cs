using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public float awarenessRadius = 8f;
    public bool isAgro;
    public bool losingAgro;
    public Material enemy;
    public Material agroMat;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
            var dist = Vector3.Distance(transform.position, playerTransform.position);

            if (dist < awarenessRadius)
            {
                isAgro = true;
            }

            if (losingAgro)
            {
                if (dist > awarenessRadius)
                {
                    isAgro = false;
                }
            }       

            if (isAgro)
            {
                GetComponent<MeshRenderer>().material = agroMat;
            }
            else
            {
                GetComponent<MeshRenderer>().material = enemy;
            }
    }

}
