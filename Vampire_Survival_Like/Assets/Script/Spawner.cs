using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPoint;

    float timer;
    int timer_e;
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
            timer_e += 1;
            Spawn();
        }
        if (timer_e> 20)
        {
            Spawn_Elete();
            timer_e = 0;
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
}
