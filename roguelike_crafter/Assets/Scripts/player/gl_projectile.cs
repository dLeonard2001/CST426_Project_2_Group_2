using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class gl_projectile : MonoBehaviour
{
    public float projectile_speed;
    public LayerMask isEnemy;
    private long damage;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    public void setDamage(long newDmg)
    {
        damage = newDmg;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 7, transform.forward,0, isEnemy);

        foreach (RaycastHit h in hits)
        {
            if (h.transform.CompareTag("enemy"))
            {
                h.transform.GetComponent<enemyHealth>().TakeDamage(damage);
                Debug.Log(damage);
                Debug.Log(hits.Length);
            }
        }
        
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,7);
    }
}
