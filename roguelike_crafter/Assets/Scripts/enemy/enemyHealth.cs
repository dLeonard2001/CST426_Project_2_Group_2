using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    
    
    public long health;

    public void TakeDamage(long damageToInflict)
    {
        health -= damageToInflict;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
        // update enemy health
    }
}
