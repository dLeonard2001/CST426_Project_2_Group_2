using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum MageState
{
    Healthy,
    InDanger
}

public class DeathMageAttack : EnemyCombat
{
    private Animator anim;
    private MageState mageState = MageState.Healthy;
    private List<string> AttackList = new List<string> { "LeftAttack", "RightAttack", "Kick" };
    private float skillCoolDown = 0;
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

                switch (mageState)
                {
                    case MageState.Healthy:
                        anim.SetTrigger(RandomAttackAnimation());
                        break;
                    case MageState.InDanger:
                        if (skillCoolDown <= 0)
                        {
                            skillCoolDown = 45f;
                            UseSkill();
                        }
                        else if(inSkill == false)
                        {
                            anim.SetTrigger("Smash");
                        }

                        break;
                }


                yield return new WaitForSeconds(enemyData.attackDelay);

                enemyBasicMovement.FinishAnimation();
            }
            else
            {
                yield return null;
            }

        }
    }

    private bool inSkill = false;

    private void UseSkill()
    {
        inSkill = true;
        anim.SetBool("Skill", inSkill);
        StartCoroutine(SkillTime());
        StartCoroutine(CheckSkillDamage());
    }

    IEnumerator SkillTime()
    {
        yield return new WaitForSeconds(6f);
        inSkill = false;
        anim.SetBool("Skill", inSkill);
    }

    private IEnumerator CheckSkillDamage()
    {
        while (inSkill)
        {
            GiveDamage(12);
            yield return new WaitForSeconds(0.8f);
        }
    }

    private static int lastAttack = int.MinValue;
    private string RandomAttackAnimation()
    {
        int index = Random.Range(0, AttackList.Count);
        while (index == lastAttack)
        {
            index = Random.Range(0, AttackList.Count);
        }
        lastAttack = index;

        return AttackList[index];
    }

    public override void Death()
    {
        anim.SetTrigger("Death");
        transform.GetComponentInChildren<Collider>().enabled = false;
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

        if (enemyData.hp <= enemyData.MaxHp / 2)
        {
            mageState = MageState.InDanger;
            enemyData.attackDelay -= 0.4f;
            enemyData.attack =  (enemyData.attack / 3) * 2;
            enemyData.defense += 2;
        }

        enemyData.hp = enemyData.hp <= 0 ? 0 : enemyData.hp;

        UpdateHealthBar();
        Debug.Log("taking " + damage);
        if (enemyData.hp <= 0)
        {
            Death();
        }
    }

    private void Update()
    {
        healthBar.transform.position = new Vector3(transform.position.x, transform.position.y + yForHealthBar, transform.position.z);
        healthBar.transform.LookAt(Camera.main.transform);
        
        skillCoolDown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.X))
        {
            GetDamage(20);
        }
    }

    public void GiveDamage()
    {
        var movement = GetComponent<EnemyBasicMovement>();

        if (movement.hasTarget())
        {
            Debug.Log("player should be taking damage");
            if (movement.InAttackRange())
            {
                
                var player = movement.GetTarget();
                //Debug.Log(player);
                player.GetComponentInParent<healthController>()?.takeDamage((long)enemyData.attack);
                //Debug.Break();
            }
        }
    }

    public void GiveDamage(float damage)
    {
        var movement = GetComponent<EnemyBasicMovement>();

        if (movement.hasTarget())
        {
            if (movement.InAttackRange())
            {
                var player = movement.GetTarget();
                player.GetComponent<healthController>()?.takeDamage((long)damage);
            }
        }
    }
}
