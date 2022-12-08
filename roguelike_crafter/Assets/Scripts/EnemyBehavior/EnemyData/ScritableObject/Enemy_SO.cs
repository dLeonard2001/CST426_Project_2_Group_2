using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "Enemy_SO", menuName = "Enemy_SO", order = 0)]
public class Enemy_SO : ScriptableObject
{
    public List<EnemyCombatData> enemyDataList;

    public EnemyCombatData GetFromList(int ID)
    {
        foreach (var enemy in enemyDataList)
        {
            if (enemy.ID == ID)
            {
                return enemy.Clone();
            }
        }
        return null;
    }
}


[System.Serializable]
public class EnemyCombatData
{
    public string name;
    public int ID;
    public float MaxHp;
    public float hp;
    public float attack;
    public float attackDelay;
    public float defense;

    public EnemyCombatData()
    {
        hp = MaxHp;
    }

    public EnemyCombatData Clone()
    {
        EnemyCombatData newData = new EnemyCombatData();
        newData.ID = this.ID;
        newData.attackDelay = this.attackDelay;
        newData.MaxHp = this.MaxHp;
        newData.hp = newData.MaxHp;
        newData.attack = this.attack;
        newData.defense = this.defense;
        return newData;
    }

}

