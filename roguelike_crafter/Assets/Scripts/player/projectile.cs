using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float projectileSpeed;
    private int damage;
    
    public void setDamage(int newDmg)
    {
        damage = newDmg;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "enemy")
        {
            collision.transform.GetComponent<enemyHealth>().TakeDamage(damage);
        }
    }
}
