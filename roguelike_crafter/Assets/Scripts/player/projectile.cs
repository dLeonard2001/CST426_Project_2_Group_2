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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("enemy"))
        {
            // Debug.Log(damage);
            collision.transform.GetComponent<enemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        
        Destroy(gameObject, 5f);
    }
}
