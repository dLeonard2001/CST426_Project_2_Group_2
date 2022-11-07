using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealthBar : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image health;
    private float maxHealth;

    public void Init(EnemyCombatData enemyData)
    {
        maxHealth = enemyData.hp;
        UpdateHealth(maxHealth);
    }

    public void UpdateHealth(float currentHealth)
    {
        health.fillAmount = currentHealth / maxHealth;
        text.text = currentHealth + "   /   " + maxHealth;
    }

}
