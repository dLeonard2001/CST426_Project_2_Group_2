using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomThing : MonoBehaviour
{
    public List<GameObject> options;
    void Awake()
    {
        GameObject me = options[Random.Range(0, options.Count)];
        Instantiate(me, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
