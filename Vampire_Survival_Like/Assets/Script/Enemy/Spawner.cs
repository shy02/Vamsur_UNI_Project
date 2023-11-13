using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
   // public GameObject Boss;
    public int enemy_count=0;
    float timer;
    public GameObject parent;
    public GameObject boss_obj;
    public GameObject GM;
    public GameObject[] enemyPrefab;
    public GameObject[] eletePrefab;
    public GameObject[] bossPrefab;
    List<GameObject>[] pools; 
    List<GameObject>[] b_pools;

    private Player player;
    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        GM = GameObject.Find("DontDestroyOnLoad").transform.GetChild(1).transform.GetChild(0).gameObject;
        player = GM.GetComponent<GameManager>().player;
        pools = new List<GameObject>[enemyPrefab.Length];
        b_pools=new List<GameObject>[bossPrefab.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
        for(int index =0; index<b_pools.Length;index++){
            b_pools[index]=new List<GameObject>();
        }
    }
    void Update()
    {
        gameObject.transform.position = player.transform.position;
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
        GameObject enemy = Instantiate(enemyPrefab[Random.Range(0,2)], spawnPoint[Random.Range(1, spawnPoint.Length-1)].position, Quaternion.identity,transform);
        enemy.transform.SetParent(parent.transform);
    }
    void Spawn_Elete()
    {
        GameObject elete_enemy = Instantiate(eletePrefab[0], spawnPoint[Random.Range(1, spawnPoint.Length-1)].position, Quaternion.identity, transform);
        elete_enemy.transform.SetParent(parent.transform);
    }
    public void Spawn_Boss()
    {
        GameObject boss = Instantiate(bossPrefab[0],spawnPoint[spawnPoint.Length-1].position,Quaternion.identity,transform);
        boss.transform.SetParent(boss_obj.transform);
    }
}
