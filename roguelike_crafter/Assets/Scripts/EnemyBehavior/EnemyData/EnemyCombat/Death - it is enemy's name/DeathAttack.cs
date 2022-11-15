using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAttack : EnemyCombat
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Init();
    }

    private void OnEnable()
    {
        EventHandler.PlayerGetHit += GiveDamage;
    }

    private void OnDisable()
    {
        EventHandler.PlayerGetHit -= GiveDamage;
    }

    public override IEnumerator Attack()
    {
        if (!enemyBasicMovement.isInAnimation)
        {

            anim.SetTrigger("Attack");

            enemyBasicMovement.StartAnimation();

            yield return new WaitForSeconds(2);

            enemyBasicMovement.FinishAnimation();
        }
        else
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

    public void GiveDamage()
    {
        var player = hitBox.GetComponent<AttackTrigger>().player;

        if (player != null)
        {
            player.GetComponent<PlayerGetAttack>().GetDamage(enemyData.attack);
            hitBox.GetComponent<AttackTrigger>().player = null;
        }

    }
}
