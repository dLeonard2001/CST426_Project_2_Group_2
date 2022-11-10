using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class spawner : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject[] enemy_spawn_locations;
    public GameObject[] player_spawn_locations;

    private bool cr_active;

    private void Awake()
    {
        int rand_index = Random.Range(0, player_spawn_locations.Length);
        player.transform.position = player_spawn_locations[rand_index].transform.position;
        StartCoroutine(spawnEnemy());
    }

    private void Update()
    {
        if (!cr_active)
            StartCoroutine(spawnEnemy());
    }

    private IEnumerator spawnEnemy()
    {
        cr_active = true;
        
        float time = 10f;

        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }

        int rand_index = Random.Range(0, enemy_spawn_locations.Length);
        enemy.transform.position = enemy_spawn_locations[rand_index].transform.position;
        Instantiate(enemy);

        cr_active = false;
    }
}
