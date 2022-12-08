using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Observer : MonoBehaviour
{
    [Header("Loot Table")] 
    
    public List<GameObject> item_objects;

    public UnityEvent enemyDeathEvent;

    private Hashtable lootTable;
    private Queue<Vector3> enemyDeath_pos;
    private float current_luck;

    // Start is called before the first frame update

    void Start()
    {
        enemyDeath_pos = new Queue<Vector3>();
        lootTable = new Hashtable();
        
        foreach (var id in item_objects)
        {
            lootTable.Add(id.GetComponent<item_id>().id, 0);
        }
    }
    

    public void enemyHasDied(Vector3 position)
    {
        Debug.Log("enemy has died");
        
        enemyDeath_pos.Enqueue(position);
        enemyDeathEvent.Invoke();
    }

    public void setCurrentLuck(float luck)
    {
        current_luck = luck;
    }

    private GameObject chooseItem()
    {
        float percent = Random.Range(0, 100);
        int itemToSpawn = Random.Range(0, lootTable.Count);
        if (percent < current_luck)
        {
            return item_objects[itemToSpawn];
        }

        return null;
    }

    public void spawnItem()
    {
        GameObject item = chooseItem();

        if (item != null)
        {
            Instantiate(item, enemyDeath_pos.Dequeue(), quaternion.identity);
        }
    }
    
    public void dropGold()
    {
        
    }

    public void dropCraftingPart()
    {
        
    }
    
}
