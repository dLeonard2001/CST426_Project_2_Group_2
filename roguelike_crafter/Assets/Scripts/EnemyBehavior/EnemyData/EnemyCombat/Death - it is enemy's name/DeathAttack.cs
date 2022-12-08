using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathAttack : EnemyCombat
{
    //Death should run faster than Player
    private Animator anim;
    private Observer gm;

    private void Start()
    {
        anim = GetComponent<Animator>();
        gm = GameObject.Find("GameManager").GetComponent<Observer>();
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

    public override IEnumerator Attack
    {
        get
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
    }

    private void Update()
    {
        healthBar.transform.position = new Vector3(transform.position.x, transform.position.y + yForHealthBar, transform.position.z);
        healthBar.transform.LookAt(Camera.main.transform);

        if(Input.GetKeyDown(KeyCode.K))
        {
            GetDamage(20);
        }
    }

    public override void Death()
    {
        anim.SetTrigger("Death");
        transform.GetComponent<Collider>().enabled = false;
        GetComponent<EnemyBasicMovement>().speed = 0;
        StopAllCoroutines();
        
        gm.enemyHasDied(transform.position);
    }

    public void CallDestory()
    {
        Destroy(healthBar);
        Destroy(this.gameObject);
    }

    public override void GetDamage(float damage)
    {
        enemyData.hp -= Mathf.Max(5, damage - enemyData.defense);
        
        enemyData.hp = enemyData.hp <= 0 ? 0 : enemyData.hp;

        UpdateHealthBar();
        
        Debug.Log("taking " + damage);

        if(enemyData.hp <= 0)
        {
            Death();
        }
    }

    public void GiveDamage()
    {
        var player = hitBox.GetComponent<AttackTrigger>().player;

        if (player != null)
        {
            //Debug.Log(player);
            player.GetComponentInParent<healthController>()?.takeDamage((long)enemyData.attack);
            //Debug.Break();
            hitBox.GetComponent<AttackTrigger>().player = null;
        }

    }
}
