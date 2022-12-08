using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class healthController : MonoBehaviour
{
    [Header("Health")]
    public long health;
    public float armor;
    private long maxHealth;

    private long testDmg;

    [Header("Health UI")] 
    public Image hp_display;
    public TextMeshProUGUI amount_of_health;


    public UnityEvent onDeathEvent;
    private void Update()
    {
        testDmg = Random.Range(0, 21);
        // if(Input.GetKeyDown(KeyCode.K))
        //     takeDamage(testDmg);
    }

    public void setCurrentHealth(long health)
    {
        this.health = health;
    }
    public void setMaxHealth(long maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public void setCurrentArmor(float newArmor)
    {
        armor = newArmor;
    }

    public void addMaxHealth(long hpToAdd)
    {
        health += hpToAdd;
        maxHealth += hpToAdd;
        
        updateUI();
        
        heal(hpToAdd);
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
        health -= Convert.ToInt64(Mathf.Max(5, damage - armor));

        if (health < 0)
        {
            Death();
        }

        // update UI
        updateUI();
    }

    public void Death()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        onDeathEvent.Invoke();
    }

    public void initializeHealth()
    {
        updateUI();
    }

    private void updateUI()
    {
        if(amount_of_health != null)    amount_of_health.text =  health + "/" + maxHealth;
        if(hp_display != null)    hp_display.fillAmount = health/Mathf.Ceil(maxHealth);
    }
}
