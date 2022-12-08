using System.Collections.Generic;
using UnityEngine;

public class PlayerMakeshiftEGrid : MonoBehaviour 
{
    public float xStart; // for now...
    public float xEnd;
    public float zStart;
    public float zEnd;
    public float timer;
    float restartTimeValue;
    public GameObject godRays;
    public List<GameObject> currentPlacements;
    bool active;

    void Start()
    {
        // get the current position of the player and set the offset on x and z start and end
        //offset -3 and +3
        restartTimeValue = timer;
        active = false;
    }

    void Update()
    {
        xStart = transform.transform.position.x - 10;
        xEnd = transform.transform.position.x + 10;
        zStart = transform.transform.position.z - 10;
        zEnd = transform.transform.position.z + 10;
        if (timer > 0 && !active)
        {
            timer -= Time.deltaTime;
        }

        else if (timer <= 0 && !active)
        {
            active = true;
            spawnGrid();
        }

        if (active)
        {
            updateCurrentPositions();
        }

    }
    
    void spawnGrid()
    {
        int randomA = Random.Range(2, 7);
        for (int a = 0; a <= randomA; a++)
        {
            int x = Random.Range((int) xStart, (int) xEnd);
            int z = Random.Range((int) zStart, (int) zEnd);
            Vector3 pos = new Vector3(x, 600, z);
            GameObject temp = godRays;
            Instantiate(temp, pos, Quaternion.identity);
            currentPlacements.Add(godRays);
        }
    }

    void updateCurrentPositions()
    {
        // we need to get the differ the spawners between the normal god rays and the player god rays
        GameObject [] temp = GameObject.FindGameObjectsWithTag("GridRay Player");
        List<GameObject> replacement;
        if (temp.Length > 0)
        {
            replacement = new List<GameObject>();
            for (int P = 0; P < temp.Length; P++)
            {
                replacement.Add(temp[P]);
            }
            currentPlacements = replacement;
            updateGrid();
        }

        else
        {
            timer = restartTimeValue;
            active = false;
        }
    }

    void updateGrid()
    {
        for (int a = 0; a < currentPlacements.Count; a++)
        {
            int x = Random.Range((int) xStart, (int) xEnd);
            int z = Random.Range((int) zStart, (int) zEnd);
            Vector3 pos = new Vector3((float)x, 600f, (float)z);
            currentPlacements[a].transform.position = pos;
        }
    }
}