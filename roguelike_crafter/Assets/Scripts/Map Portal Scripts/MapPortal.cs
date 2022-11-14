using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPortal : MonoBehaviour 
{
    public GameObject TP1;
    public GameObject TP2;
    public List<GameObject> tp1Locations;
    public List<GameObject> tp2Locations;
    
    void Awake()
    {
        setLocations();
        assignTPS();
    }

    void setLocations()
    {
       GameObject [] tempA = GameObject.FindGameObjectsWithTag("TP1 Local");
       GameObject [] tempB = GameObject.FindGameObjectsWithTag("TP2 Local");
       for (int a = 0; a < tempA.Length; a++)
       {
           tp1Locations.Add(tempA[a]);
       }

       for (int b = 0; b < tempB.Length; b++)
       {
           tp2Locations.Add(tempB[b]);
       }
    }
    
    void assignTPS()
    {
        int assignedTP1 = Random.Range(0, tp1Locations.Count);
        int assignedTP2 = Random.Range(0, tp2Locations.Count);
        Vector3 spin1 = new Vector3(0f, Random.Range(-359, 359), 0f);
        Vector3 spin2 = new Vector3(0f, Random.Range(-359, 359), 0f);

        Instantiate(TP1, tp1Locations[assignedTP1].transform.position, Quaternion.Euler(spin1));
        Instantiate(TP2, tp2Locations[assignedTP2].transform.position, Quaternion.Euler(spin2));
    }
}