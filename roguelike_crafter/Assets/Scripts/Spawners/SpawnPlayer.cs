using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> possibleLocations;

    void Start()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Player");
        for (int a = 0; a < temp.Length; a++)
        {
            possibleLocations.Add(temp[a]);
        }

        //Vector3 rotation = new Vector3(0f, Random.Range(-359, 359), 0f);

        int selection = Random.Range(0, temp.Length);
        Instantiate(player, temp[selection].transform.position, Quaternion.identity);//Quaternion.Euler(rotation));
        //Destroy(gameObject);

    }
}
