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
    private DeathMageAttack enemy;
    private DeathAttack enemy_2;
    private bool cr_active;

    private void Start()
    {
        stackCounter = 0;
        enemy = GetComponent<DeathMageAttack>();

        if (!enemy)
        {
            enemy_2 = GetComponent<DeathAttack>();
        }
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

        long damage;

        if (enemy)
        {
            damage = Convert.ToInt64(enemy.enemyData.hp * 0.1f);
        }
        else
        {
            damage = Convert.ToInt64(enemy_2.enemyData.hp * 0.1f);
        }
        
        

        while (usagesLeft > 0)
        {
            useBleedStackTimer -= Time.fixedDeltaTime;
            if (useBleedStackTimer < 0)
            {
                // Debug.LogWarning("taking bleed damage");
                if (enemy)
                {
                    enemy.GetDamage(damage);
                }
                else
                {
                    enemy_2.GetDamage(damage);
                }
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
