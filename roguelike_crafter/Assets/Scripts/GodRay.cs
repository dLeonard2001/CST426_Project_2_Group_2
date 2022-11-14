using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodRay : MonoBehaviour
{
    public Vector3 pos;
    string hitName;

    void displayCord()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit);
        pos = new Vector3(transform.position.x, transform.position.y - hit.distance, transform.position.z);
        //Debug.Log(pos);
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.blue);
        //Debug.Log(hit.transform.name);
        hitName = hit.transform.tag;
        displayCord();
    }

    public Vector3 getPosition()
    {
        return pos;
    }

    public string getHitTarget()
    {
        return hitName;
    }
    
}
