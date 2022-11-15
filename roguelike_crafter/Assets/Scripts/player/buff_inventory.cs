using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff_inventory : MonoBehaviour
{
    public float useBleedStackTimer;
    private float maxTimer;
    private int stackCounter;
    private int usagesLeft;
    private enemyHealth enemy;
    private bool cr_active;

    private void Start()
    {
        enemy = GetComponent<enemyHealth>();
        maxTimer = useBleedStackTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (stackCounter > 0 && !cr_active)
        {
            StartCoroutine(performBleedStack());
        }
    }

    public void addBleedAffect()
    {
        if (stackCounter >= 3)
        {
            stackCounter = 3;
            refreshTimer();
        }
        else
        {
            usagesLeft = 2;
            stackCounter++; 
        }
    }

    private IEnumerator performBleedStack()
    {
        cr_active = true;
        Debug.LogWarning(stackCounter);
        
        while (usagesLeft > 0)
        {
            useBleedStackTimer -= Time.deltaTime;
            if (useBleedStackTimer > 0)
            {
                usagesLeft--;
                refreshTimer();
            }
            
            yield return null;
        }
        
        long damage = Convert.ToInt64(enemy.health * 0.1f);
        // Debug.LogWarning(enemy.health + "before");
        enemy.TakeDamage(damage);
        // Debug.LogWarning(enemy.health + "after");

        Debug.LogWarning(usagesLeft + " stack usages");
        
        stackCounter--;

        refreshTimer();
        cr_active = false;
    }

    public void refreshTimer()
    {
        useBleedStackTimer = maxTimer;
    }
}
