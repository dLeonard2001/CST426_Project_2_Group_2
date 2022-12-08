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
        
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 20, transform.forward,0);

        Debug.Log(hits.Length);
        foreach (RaycastHit h in hits)
        {
            if (h.transform.CompareTag("enemy") || h.transform.CompareTag("Enemy"))
            {
                //Debug.Log("enemy taking dmg by gl");
                //Debug.Log(damage);
                if (h.transform.GetComponent<DeathMageAttack>())
                {
                    h.transform.GetComponent<DeathMageAttack>().GetDamage(damage);
                }

                if (h.transform.GetComponent<DeathAttack>())
                {
                    h.transform.GetComponent<DeathAttack>().GetDamage(damage);
                }
                
            }
        }
        
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,7);
    }
}
