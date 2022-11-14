using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomThing2 : MonoBehaviour
{
    public List<GameObject> options;

    public void SpawnRandomObject(Vector3 pos)
    {
        GameObject me = options[Random.Range(0, options.Count)];
        Vector3 rotation = new Vector3(0f, Random.Range(-359, 359), 0f);
        Instantiate(me, pos, Quaternion.Euler(rotation));
        Destroy(gameObject);
    }
}
