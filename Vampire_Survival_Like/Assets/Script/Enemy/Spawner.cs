using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
   // public GameObject Boss;
    public int enemy_count=0;
    float timer;

    public GameObject[] enemyPrefab;
    public GameObject[] bossPrefab;
    List<GameObject>[] pools;
    List<GameObject>[] b_pools;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        pools = new List<GameObject>[enemyPrefab.Length];
        b_pools=new List<GameObject>[bossPrefab.Length];
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            timer = 0;
            enemy_count += 1;
            Spawn(timer);
        }
        if (enemy_count >= 20)
        {
            Spawn_Elete();
            enemy_count = 0;
        }
    }

    void Spawn(float time)
    {
        GameObject enemy = Instantiate(enemyPrefab[0], spawnPoint[Random.Range(1, spawnPoint.Length-2)].position, Quaternion.identity,transform);
        Destroy(enemy, 5f);

    }
    void Spawn_Elete()
    {
        GameObject elete_enemy = Instantiate(enemyPrefab[1], spawnPoint[Random.Range(1, spawnPoint.Length-2)].position, Quaternion.identity, transform);
    }
    public void Spawn_Boss()
    {
        //Boss.SetActive(true);
        GameObject boss = Instantiate(bossPrefab[0],spawnPoint[spawnPoint.Length-1].position,Quaternion.identity);
    }
}
