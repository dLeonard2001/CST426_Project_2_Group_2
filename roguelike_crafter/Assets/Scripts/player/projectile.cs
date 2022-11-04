using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float projectileSpeed;
    private long damage;
    
    public void setDamage(long newDmg)
    {
        damage = newDmg;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("enemy"))
        {
            // Debug.Log(damage);
            other.transform.GetComponent<enemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }

        Destroy(gameObject, 5f);
    }
}
