using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControl : MonoBehaviour
{
    private Rigidbody rb;
    private bool startFalling = true;
    public PatrolBehavior patrol;

    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (startFalling)
        {
            rb.velocity = new Vector3(0, -15, 0);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        startFalling = false;
        GetComponent<BoxCollider>().isTrigger = true;
        gameObject.layer = LayerMask.NameToLayer("Target");
        rb.constraints = RigidbodyConstraints.FreezeAll;
        StartCoroutine(ChangeLayer());
    }

    IEnumerator ChangeLayer()
    {
        yield return new WaitForSeconds(1f);

        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    public void Reset()
    {
        GetComponent<BoxCollider>().isTrigger = false;
        startFalling = true;
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        rb.constraints = RigidbodyConstraints.None;
        patrol.RandomPosition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Reset();
        }
    }


}
