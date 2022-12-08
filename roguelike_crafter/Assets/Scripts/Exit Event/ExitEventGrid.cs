// TODO: Make this like MakeshiftGrid.cs but have the spawns be on a timer and set it to the "exit" object and test if this shit works...
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitEvent : MonoBehaviour
{
    public GameObject ePlacement;
    public List<GameObject> currentPlacements;
    public int xStart = 0;
    public int xLast = 50;
    public int zStart = 0;
    public int zLast = 50;
    public float etimer = 15f;
    public float endTimer = 90f;
    bool charging;
    // Start is called before the first frame update
    void Start()
    {
        charging = false;
        // spawningOtherObjects = true;
        // spawningEn = false;
        // spawnGrid();
    }

    public void startCharging()
    {
        charging = true;
        spawnGrid();
    }

    void spawnGrid()
    {
        if (charging)
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
        if (charging && endTimer > 0)
        {
            updateCurrentPlacement();
            endTimer -= Time.deltaTime;
        }

        else if (endTimer <= 0)
        {
            charging = false;
            endTimer = 0;
        }
    }

    void updateCurrentPlacement()
    {
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

            if (etimer <= 0)
            {
                etimer = 30f;
                spawnGrid();
            }
            etimer -= Time.deltaTime;
        }

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
