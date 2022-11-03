using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class healthController : MonoBehaviour
{
    [Header("Health")]
    public long health;
    private long maxHealth;

    [Header("Health UI")] 
    public Image hp_display;
    public TextMeshProUGUI amount_of_health;


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
        hp_display.fillAmount = health/maxHealth;
    }
}
