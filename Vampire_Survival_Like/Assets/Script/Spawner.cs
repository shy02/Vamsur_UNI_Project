using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject Boss;
    int enemy_count=0;
    float timer;

    public GameObject[] enemyPrefab;
    List<GameObject>[] pools; 

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        pools = new List<GameObject>[enemyPrefab.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            timer = 0;
            enemy_count += 1;
            Spawn();
        }
        if (enemy_count >= 20)
        {
            Spawn_Elete();
            enemy_count = 0;
        }
    }

    void Spawn()
    {
        GameObject enemy = Instantiate(enemyPrefab[0], spawnPoint[Random.Range(1, spawnPoint.Length)].position, Quaternion.identity,transform);
        Destroy(enemy, 5f);
    }
    void Spawn_Elete()
    {
        GameObject elete_enemy = Instantiate(enemyPrefab[1], spawnPoint[Random.Range(1, spawnPoint.Length)].position, Quaternion.identity, transform);
        Destroy(elete_enemy, 10f);
    }
    public void Spawn_Boss()
    {
        Boss.SetActive(true);
    }
}
