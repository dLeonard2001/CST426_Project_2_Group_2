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
        
        if (other.CompareTag("enemy") || other.CompareTag("Enemy"))
        {
            // Debug.Log(other.name);
            
            if (other.transform.GetComponent<DeathMageAttack>())
            {
                other.transform.GetComponent<DeathMageAttack>().GetDamage(damage);
            }

            if (other.transform.GetComponent<DeathAttack>())
            {
                other.transform.GetComponent<DeathAttack>().GetDamage(damage);
            }
            // other.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * knockback_force, ForceMode.Impulse);
            // Debug.Break();
        }
    }

    public void setDamage(long newDamage)
    {
        damage = newDamage;
    }
}
