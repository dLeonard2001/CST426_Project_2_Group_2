using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyCombat : MonoBehaviour
{
    [Header("Require")]
    public int ID;
    [SerializeField] protected EnemyBasicMovement enemyBasicMovement;
    [SerializeField] protected Collider hitBox;

    [Header("No Need")]
    [SerializeField] protected EnemyCombatData enemyData;
    protected GameObject healthBar;
    [SerializeField] protected float yForHealthBar = 1f;
    private void Start()
    {
        Init();
    }

    protected void Init()
    {
        var dataList = Resources.Load<Enemy_SO>("ScriptableObjects/EnemyData/EnemyData");

        if (dataList != null)
        {
            Debug.Log("Loading..");
            enemyData = dataList.GetFromList(ID).Clone();
            healthBar = Instantiate(Resources.Load<GameObject>("Prefabs/HealthBar"), FindObjectOfType<Canvas>().transform);
            healthBar.GetComponent<EnemyHealthBar>().Init(enemyData);
        }
        else
        {
            Debug.Log("No such Enemy");
        }

    }

    public abstract IEnumerator Attack { get; }

    public abstract void GetDamage(float damage);
    public abstract void Death();
    public void StopHitBox()
    {
        hitBox.enabled = false;
    }

    public void StartHitBox()
    {
        hitBox.enabled = true;
    }

    protected void UpdateHealthBar()
    {
        healthBar.GetComponent<EnemyHealthBar>().UpdateHealth(enemyData.hp);
    }
}
