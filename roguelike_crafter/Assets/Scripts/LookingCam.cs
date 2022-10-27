using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingCam : MonoBehaviour
{
    public Transform positions;
    public float mod = 5f;
    float mouseSensitivity = 3f;
    public Vector2 mouseTurn;
    float xRotation = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseTurn.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseTurn.y = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        xRotation -= mouseTurn.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, mouseTurn.x, 0f);
    }
}