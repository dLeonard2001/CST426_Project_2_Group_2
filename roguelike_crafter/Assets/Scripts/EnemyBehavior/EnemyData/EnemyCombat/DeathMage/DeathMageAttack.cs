using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMageAttack : EnemyCombat
{
    public override IEnumerator Attack
    {
        get
        {
            yield return null;
        }
    }

    public override void Death()
    {

    }

    public override void GetDamage(float damage)
    {

    }

    private void Update()
    {
        healthBar.transform.position = new Vector3(transform.position.x, transform.position.y + yForHealthBar, transform.position.z);
        healthBar.transform.LookAt(Camera.main.transform);
    }

}
