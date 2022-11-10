
using UnityEngine;

public class MapPortal : MonoBehaviour 
{
    bool hasSpawned;
    Vector3 portA;
    Vector3 portB;

    void Start() 
    {
        hasSpawned = false;        
    }

    void setLocations()
    {
        GameObject[] possibleLocations = GameObject.FindGameObjectsWithTag("Teleporter");
        if (possibleLocations.Length > 2)
        {
            for (int a = 0; a < possibleLocations.Length - 2; a++)
            {
                Destroy(possibleLocations[Random.Range(0, possibleLocations.Length)]);
            }
        }
        portA = possibleLocations[0].transform.position;
        portB = possibleLocations[1].transform.position;
        hasSpawned = true;
    }
    
    void Update()
    {
        if (!hasSpawned)
        {
            setLocations();
        }
    }   
}