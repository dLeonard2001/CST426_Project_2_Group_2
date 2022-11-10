//TODO Do the same thing for the enemies only do it once
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeshiftGrid : MonoBehaviour
{
    public GameObject placement;
    public GameObject ePlacement;
    public List<GameObject> currentPlacements;
    public int xStart = 77;
    public int xLast = 947;
    public int zStart = 18;
    public int zLast = 955;
    public float timer = 30f;
    bool spawningOtherObjects, spawningEn;
    // Start is called before the first frame update
    void Start()
    {
        spawningOtherObjects = true;
        spawningEn = false;
        spawnGrid();
    }

    void spawnGrid()
    {
        if (spawningOtherObjects)
        {
            for (int a = 0; a <= 10; a++)
            {
                int x = Random.Range(xStart, xLast);
                int z = Random.Range(zStart, zLast);
                Vector3 pos = new Vector3((float)x, 800f, (float)z);
                GameObject temp = placement;
                Instantiate(temp, pos, Quaternion.identity);
                currentPlacements.Add(temp);
            }
        }
        
        else
        {
            for (int a = 0; a <= 15; a++)
            {
                int x = Random.Range(xStart, xLast);
                int z = Random.Range(zStart, zLast);
                Vector3 pos = new Vector3((float)x, 800f, (float)z);
                GameObject temp = ePlacement;
                Instantiate(temp, pos, Quaternion.identity);
                currentPlacements.Add(temp);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateCurrentPlacement();
    }

    void updateCurrentPlacement()
    { // ! if objectflag here
        GameObject[] temp = GameObject.FindGameObjectsWithTag("GridRay");
        List<GameObject> replacement;
        if (temp.Length > 0)
        {
            replacement = new List<GameObject>();
            for (int a = 0; a < temp.Length; a++)
            {
                replacement.Add(temp[a]);
            }

            currentPlacements = replacement;
            if (currentPlacements.Count > 0)
            {
                UpdateGrid();
            }

        }

        else
        {
            if (spawningOtherObjects)
            {
                spawningOtherObjects = false;
                spawningEn = true;
                spawnGrid();
            }
            
            else
            {
                if (timer <= 0)
                {
                    timer = 30f;
                    spawnGrid();
                }
                timer -= Time.deltaTime;
            }
            //Destroy(gameObject);
        }
        // ! Same thing for enemies but do not destroy yourself
    }

    void UpdateGrid()
    {
        for (int a = 0; a < currentPlacements.Count; a++)
        {
            int x = Random.Range(xStart, xLast);
            int z = Random.Range(zStart, zLast);
            Vector3 pos = new Vector3((float)x, 800f, (float)z);
            currentPlacements[a].transform.position = pos;
        }
    }
}
