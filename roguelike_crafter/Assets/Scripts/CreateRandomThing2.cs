using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomThing2 : MonoBehaviour
{
    public List<GameObject> options;

    public void SpawnRandomObject(Vector3 pos)
    {
        GameObject me = options[Random.Range(0, options.Count)];
        Instantiate(me, pos, Quaternion.identity);
        Destroy(gameObject);
    }
}
