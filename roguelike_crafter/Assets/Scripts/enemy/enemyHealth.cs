using System;
using UnityEngine;
using UnityEngine.Events;

public class enemyHealth : MonoBehaviour
{
    public long health;
    public Observer observer;

    private void Awake()
    {
        observer = GameObject.FindWithTag("gamemanager").GetComponent<Observer>();
    }

    public void TakeDamage(long damageToInflict)
    {
        health -= damageToInflict;

        if (health <= 0)
        {
            observer.enemyHasDied(transform.position);
            Destroy(gameObject);
        }
        
        // update enemy health
    }
    
    
}
