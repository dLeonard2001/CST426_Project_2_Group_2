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
        stackCounter = 0;
        enemy = GetComponent<enemyHealth>();
        maxTimer = useBleedStackTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (stackCounter > 0 && !cr_active)
        {
            Debug.LogWarning(stackCounter + " update");
            usagesLeft = 2;
            StartCoroutine(performBleedStack());
        }
    }

    public void addBleedAffect()
    {
        
        if(stackCounter < 3){
            Debug.LogWarning(stackCounter + " bleed stacks");
            Debug.Log("check");
            stackCounter++; 
        }
    }

    private IEnumerator performBleedStack()
    {
        cr_active = true;
        // Debug.LogWarning(stackCounter);
        
        long damage = Convert.ToInt64(enemy.health * 0.1f);

        while (usagesLeft > 0)
        {
            useBleedStackTimer -= Time.fixedDeltaTime;
            if (useBleedStackTimer < 0)
            {
                // Debug.LogWarning("taking bleed damage");
                enemy.TakeDamage(damage);
                usagesLeft--;
                refreshTimer();
            }
            
            yield return null;
        }
        
        
        // Debug.LogWarning(enemy.health + "before");
        
        // Debug.LogWarning(enemy.health + "after");

        // Debug.LogWarning(usagesLeft + " stack usages");
        
        stackCounter--;

        refreshTimer();
        cr_active = false;
    }

    public void refreshTimer()
    {
        useBleedStackTimer = maxTimer;
    }
}
