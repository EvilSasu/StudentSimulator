using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float xMousePos;
    private float smoothMousePos;

    public float sensitivity = 1;
    public float smoothing = 1.5f;

    private float currentLookPos;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayer();
    }

    private void GetInput()
    {
        xMousePos = Input.GetAxisRaw("Mouse X");
    }

    private void ModifyInput()
    {
        xMousePos *= sensitivity * smoothing;
        smoothMousePos = Mathf.Lerp(smoothMousePos, xMousePos, 1f / smoothing);
    }

    private void MovePlayer()
    {
        currentLookPos += smoothMousePos;
        transform.localRotation = Quaternion.AngleAxis(currentLookPos, transform.up);
    }
}
