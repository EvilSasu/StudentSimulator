using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private Vector3 offset;
    public bool follow;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!follow) return;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + offset.z);
    }
}
