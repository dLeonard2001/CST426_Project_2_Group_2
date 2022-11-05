using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Observer : MonoBehaviour
{
    [Header("Loot Table")] 
    public Hashtable lootTable;
    public List<GameObject> all_item_ids;

    public UnityEvent enemyDeathEvent;

    private List<Vector3> enemy_death_pos;
    private float current_luck;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var id in all_item_ids)
        {
            lootTable.Add(id.GetComponent<item_id>().id, 0);
        }
    }

    public void enemyHasDied(Vector3 position)
    {
        enemy_death_pos.Add(position);
        enemyDeathEvent.Invoke();
    }

    public void setCurrentLuck(float luck)
    {
        current_luck = luck;
    }

    public void chooseItem()
    {
        float percent = Random.Range(0, 101);
        float itemToSpawn = Random.Range(0, lootTable.Count);
        if (percent < current_luck)
        {
            Debug.Log(itemToSpawn);
        }
    }
    
}
