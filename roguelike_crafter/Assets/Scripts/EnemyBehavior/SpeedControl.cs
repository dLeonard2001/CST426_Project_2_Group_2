using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpeedControl : MonoBehaviour
{
    private Rigidbody rb;
    public bool startFalling = true;

    private void OnEnable()
    {
        startFalling = true;
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        rb = GetComponent<Rigidbody>();
        Reset();
    }

    private void FixedUpdate()
    {
        if (startFalling)
        {
            rb.velocity = new Vector3(0, -10, 0);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        startFalling = false;
        gameObject.layer = LayerMask.NameToLayer("Target");
        StartCoroutine(WaitAndUnenable());
    }

    IEnumerator WaitAndUnenable()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        GetComponent<BoxCollider>().isTrigger = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        gameObject.SetActive(false);
    }

    public void Reset()
    {
        GetComponent<BoxCollider>().isTrigger = false;
        startFalling = true;
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        rb.constraints = RigidbodyConstraints.None;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Reset();
        }
    }
}
