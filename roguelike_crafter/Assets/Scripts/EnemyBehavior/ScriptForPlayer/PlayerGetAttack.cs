using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetAttack : MonoBehaviour
{
    [SerializeField] private float health;
    public void GetDamage(float damage)
    {
        health -= damage;
    }
}
