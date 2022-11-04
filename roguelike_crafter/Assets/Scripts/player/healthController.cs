using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class healthController : MonoBehaviour
{
    [Header("Health")]
    public long health;
    private long maxHealth;

    private long testDmg;

    [Header("Health UI")] 
    public Image hp_display;
    public TextMeshProUGUI amount_of_health;


    private void Update()
    {
        testDmg = Random.Range(1, 21);
        if(Input.GetKeyDown(KeyCode.K))
            takeDamage(testDmg);
    }

    public void setCurrentHealth(long health)
    {
        this.health = health;
    }
    public void setMaxHealth(long maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public void heal(long hpToHeal)
    {
        health += hpToHeal;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        
        // update UI
        updateUI();
    }

    public void takeDamage(long damage)
    {
        health -= damage;

        if (health < 0)
        {
            Death();
        }

        // update UI
        updateUI();
    }

    public void Death()
    {
        Debug.Break();
    }

    public void initializeHealth()
    {
        updateUI();
    }

    private void updateUI()
    {
        amount_of_health.text =  health + "/" + maxHealth;
        hp_display.fillAmount = health/Mathf.Ceil(maxHealth);
    }
}
