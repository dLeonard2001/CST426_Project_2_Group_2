using System;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float projectileSpeed;
    private bool isHollowPoint;
    private long damage;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    public void setDamage(long newDmg)
    {
        damage = newDmg;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("enemy") || other.transform.CompareTag("Enemy"))
        {
            DeathMageAttack enemy = other.transform.GetComponent<DeathMageAttack>();
            DeathAttack enemy_2 = other.transform.GetComponent<DeathAttack>();
            if (enemy)
            {
                enemy.GetDamage(damage);
            }
            else
            {
                enemy_2.GetDamage(damage);
            }
            buff_inventory affect = other.transform.GetComponent<buff_inventory>();
            // Debug.Log(damage);
            
            // Debug.LogWarning(isHollowPoint);

            if (isHollowPoint)
            {
                // Debug.LogWarning("applying bleed affect");
                affect.addBleedAffect();
            }
            
            
        }
        Destroy(gameObject);
    }

    public void setHollowPointStatus(bool status)
    {
        isHollowPoint = status;
        
        // Debug.LogWarning(isHollowPoint + " changing hollow point status");
    }
}
