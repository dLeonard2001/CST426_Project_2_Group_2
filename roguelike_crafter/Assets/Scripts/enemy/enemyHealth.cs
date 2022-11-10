using System;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public long health;
    public Observer manager;

    // NEEDS TO BE CHANGED
    // ONLY USING FIND WITH TAG FOR PLAYTEST PURPOSES
    private void Start()
    {
        manager = GameObject.FindWithTag("gamemanager").GetComponent<Observer>();
    }

    public void TakeDamage(long damageToInflict)
    {
        health -= damageToInflict;

        if (health <= 0)
        {
            manager.enemyHasDied(transform.position);
            Destroy(gameObject);
        }
        
        // update enemy health
    }
    
    
}
