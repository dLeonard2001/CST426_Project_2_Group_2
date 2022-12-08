using System.Collections.Generic;
using UnityEngine;

public class EndPortalEGrid : MonoBehaviour
{
    public float xStart, xEnd, zStart, zEnd, timer, restartTimer, timer2;
    public bool triggerEnd, active;

    public GameObject godRays;
    public List<GameObject> currentPlacements;

    void Start()
    {
        timer = 20f;
        restartTimer = 20f;
        triggerEnd = false;
        active = false;
        xStart = transform.parent.transform.position.x - 15f;
        xEnd = transform.parent.transform.position.x + 15f;
        zStart = transform.parent.transform.position.z - 15f;
        zEnd = transform.parent.transform.position.z + 15f;
        timer2 = 69f;
    }

    void Update()
    {
        if (triggerEnd)
        {
            timer2 -= Time.deltaTime;

            if (timer2 < 0)
            {
                triggerEnd = false;
                active = false;
                timer = restartTimer;

            }
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


    }

    public void startEvent()
    {
        triggerEnd = true;
    }

    void spawnGrid()
    {
        int randomA = Random.Range(2, 7);
        for (int a = 0; a <= randomA; a++)
        {
            int x = Random.Range((int)xStart, (int)xEnd);
            int z = Random.Range((int)zStart, (int)zEnd);
            Vector3 pos = new Vector3(x, 600, z);
            GameObject temp = godRays;
            Instantiate(temp, pos, Quaternion.identity);
            currentPlacements.Add(godRays);
        }
    }

    void updateCurrentPositions()
    {
        GameObject[] temp = GameObject.FindGameObjectsWithTag("GridRay End");
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
            timer = restartTimer;
            active = false;
        }
    }

    void updateGrid()
    {
        for (int a = 0; a < currentPlacements.Count; a++)
        {
            int x = Random.Range((int)xStart, (int)xEnd);
            int z = Random.Range((int)zStart, (int)zEnd);
            Vector3 pos = new Vector3((float)x, 600f, (float)z);
            currentPlacements[a].transform.position = pos;
        }
    }
}
