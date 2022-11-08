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
    public int ID;
    public float hp;
    public float attack;
    public float defense;

    public EnemyCombatData Clone()
    {
        EnemyCombatData newData = new EnemyCombatData();
        newData.ID = this.ID;
        newData.hp = this.hp;
        newData.attack = this.attack;
        newData.defense = this.defense;
        return newData;
    }

}

