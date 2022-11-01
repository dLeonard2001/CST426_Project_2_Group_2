using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int health;

    public void TakeDamage(int damageToInflict)
    {
        health -= damageToInflict;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
        // update enemy health
    }
}
