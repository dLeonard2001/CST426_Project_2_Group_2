using System;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float projectileSpeed;
    private bool isHollowPoint;
    private long damage;

    private void Start()
    {
        isHollowPoint = false;
        Destroy(gameObject, 10f);
    }

    public void setDamage(long newDmg)
    {
        damage = newDmg;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("enemy"))
        {
            enemyHealth enemy = other.transform.GetComponent<enemyHealth>();
            buff_inventory affect = other.transform.GetComponent<buff_inventory>();
            // Debug.Log(damage);

            if (isHollowPoint)
            {
                Debug.LogWarning("applying bleed affect");
                affect.addBleedAffect();
            }
            
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
