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
    public GameObject[] elete_enemyPrefab;
    public GameObject[] bossPrefab;
    //List<GameObject>[] pools;
    //List<GameObject>[] b_pools;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        //pools = new List<GameObject>[enemyPrefab.Length];
        //b_pools=new List<GameObject>[bossPrefab.Length];
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            timer = 0;
            enemy_count += 1;
            Spawn(GameManager.instance.stage);
        }
        if (enemy_count >= 20)
        {
            Spawn_Elete(GameManager.instance.stage);
            enemy_count = 0;
        }
    }

    void Spawn(int stage)
    {
        int index = stage * 2;
        GameObject enemy = Instantiate(enemyPrefab[Random.Range(index,index+2)], spawnPoint[Random.Range(1, spawnPoint.Length-2)].position, Quaternion.identity,transform);
    }
    void Spawn_Elete(int stage)
    {
        GameObject elete_enemy = Instantiate(elete_enemyPrefab[stage], spawnPoint[Random.Range(1, spawnPoint.Length-2)].position, Quaternion.identity, transform);
    }
    public void Spawn_Boss(int stage)
    {
        GameObject boss = Instantiate(bossPrefab[stage],spawnPoint[spawnPoint.Length-1].position,Quaternion.identity);
    }
}
