using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyCombat : MonoBehaviour
{
    [Header("Require")]
    public int ID;
    [Header("No Need")]
    [SerializeField] protected EnemyCombatData enemyData;
    protected GameObject healthBar;
    [SerializeField] protected float yForHealthBar = 1f;
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        var dataList = Resources.Load<Enemy_SO>("ScriptableObjects/EnemyData/EnemyData");
        if(dataList != null)
        {
            enemyData = dataList.GetFromList(ID);
            healthBar = Instantiate(Resources.Load<GameObject>("Prefabs/HealthBar"), FindObjectOfType<Canvas>().transform);
            healthBar.GetComponent<EnemyHealthBar>().Init(enemyData);
        }
        else
            Debug.Log("No such Enemy");
        
    }

    public abstract void Attack();
    public abstract void GetDamage(float damage);
    public abstract void Death();
}
