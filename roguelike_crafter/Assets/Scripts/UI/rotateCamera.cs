using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCamera : MonoBehaviour
{

    public Camera mainCam;
    public float x_rotation;
    public float y_rotation;
    public float z_rotation;
    
    public bool startRotation;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        mainCam.transform.Rotate(new Vector3(0,y_rotation,0));
    }
}
