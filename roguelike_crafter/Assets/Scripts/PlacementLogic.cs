using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementLogic : MonoBehaviour
{
    public float yGate;
    public float yNegativeGate;
    List<GameObject> rays;
    public List<Vector3> markers;
    public bool passed;
    CreateRandomThing2 spawner;
    // Start is called before the first frame update
    void Start()
    {
        passed = false;
        rays = new List<GameObject>();
        markers = new List<Vector3>();
        spawner = GetComponent<CreateRandomThing2>();
        for (int a = 0; a < transform.childCount; a++)
        {
            rays.Add(transform.GetChild(a).gameObject);
            markers.Add(Vector3.zero);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int a = 0; a < transform.childCount; a++)
        {
            GodRay temp = transform.GetChild(a).GetComponent<GodRay>();
            markers[a] = temp.getPosition();
        }
        yGate = markers[0].y + 1;
        yNegativeGate = markers[0].y - 1;
        passed = playableArea();
        
        if (passed)
        {
            spawner.SpawnRandomObject(markers[0]);
        }
    }

    bool playableArea()
    {
        for (int a = 0; a < markers.Count; a++)
        {
            if (markers[a].y <= yGate && markers[a].y >= yNegativeGate)
            {
                GodRay temp = transform.GetChild(a).GetComponent<GodRay>();
                if (temp.getHitTarget().Equals("Level"))
                {
                    continue;
                }
                
                else 
                {
                    return false;
                }
            }

            else 
            {
                return false;
            }
        }
        return true;
    }
}
