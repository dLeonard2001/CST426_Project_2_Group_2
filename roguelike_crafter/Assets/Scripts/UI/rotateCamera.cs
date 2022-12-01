using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class rotateCamera : MonoBehaviour
{

    public Camera mainCam;
    public float x_axis;
    public float y_axis;
    public float z_axis;

    public float timer;
    private float maxTime;

    private void Start()
    {
        maxTime = timer;
        x_axis = Random.Range(-0.25f, 0.25f);
        y_axis = Random.Range(-0.25f, 0.25f);
        z_axis = Random.Range(-0.25f, 0.25f);
    }

    private void FixedUpdate()
    {
        if (timer < 0)
        {
            timer = maxTime;
            x_axis = Random.Range(-0.25f, 0.25f);
            y_axis = Random.Range(-0.25f, 0.25f);
            z_axis = Random.Range(-0.25f, 0.25f);
        }

        timer -= Time.fixedDeltaTime;
        mainCam.transform.Rotate(new Vector3(x_axis, y_axis, z_axis));
    }
}
