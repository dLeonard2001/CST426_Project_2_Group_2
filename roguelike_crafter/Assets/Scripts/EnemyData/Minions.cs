using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minions : EnemyCombat
{
    public override void Attack()
    {

    }

    public override void GetDamage(float damage)
    {
        enemyData.hp -= damage;
        if(enemyData.hp <= 0)
        {
            Death();
        }
    }

    private void Update()
    {
        healthBar.transform.position = new Vector3(transform.position.x, transform.position.y + yForHealthBar, transform.position.z);
        healthBar.transform.LookAt(Camera.main.transform);
    }

    public override void Death()
    {
        Destroy(this);
    }
}
