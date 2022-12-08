using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomThing2 : MonoBehaviour
{
    public List<GameObject> options;
    public static bool isSpawner = false;

    public void SpawnRandomObject(Vector3 pos)
    {
        GameObject me = options[Random.Range(0, options.Count)];
        Vector3 rotation = new Vector3(0f, Random.Range(-359, 359), 0f);
        if (me.tag.Equals("End") && isSpawner)
        {
            SpawnRandomObject(pos);
            return;
        }

        if (me.tag.Equals("End") && !isSpawner)
        {
            isSpawner = true;
        }
        Instantiate(me, pos, Quaternion.Euler(rotation));
        Destroy(gameObject);
    }

    public void SpawnRandomObjectAdjusted(Vector3 pos)
    {
        GameObject me = options[Random.Range(0, options.Count)];
        Vector3 rotation = new Vector3(0f, Random.Range(-359, 359), 0f);
        Vector3 adjustedPos = new Vector3(pos.x, pos.y + 1, pos.z);
        Instantiate(me, adjustedPos, Quaternion.Euler(rotation));
        Destroy(gameObject);
    }
}
