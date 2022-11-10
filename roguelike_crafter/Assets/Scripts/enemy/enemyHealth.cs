using System;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public long health;
    public Observer manager;
    public GameObject player;

    // NEEDS TO BE CHANGED
    // ONLY USING FIND WITH TAG FOR PLAYTEST PURPOSES
    private void Start()
    {
        manager = GameObject.FindWithTag("gamemanager").GetComponent<Observer>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        transform.LookAt(player.transform);
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
