using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPoint;
    public GameObject Boss;
    int enemy_count=0;
    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>(); 
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
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(0, spawnPoint.Length)].position;
    }
    void Spawn_Elete()
    {
        GameObject enemy = GameManager.instance.pool.Get(1);
        enemy.transform.position = spawnPoint[Random.Range(0, spawnPoint.Length)].position;
    }
    public void Spawn_Boss()
    {
        Boss.SetActive(true);
    }
}
