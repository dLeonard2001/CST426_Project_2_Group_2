using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon_hitbox : MonoBehaviour
{
    public float knockback_force;
    private long damage;
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            other.GetComponent<enemyHealth>().TakeDamage(damage);
            other.GetComponent<Rigidbody>().AddForce(-other.transform.forward * knockback_force, ForceMode.Impulse);
        }
    }

    public void setDamage(long newDamage)
    {
        damage = newDamage;
    }
}
