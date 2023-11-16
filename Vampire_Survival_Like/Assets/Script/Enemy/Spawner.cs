using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
   // public GameObject Boss;
    public int enemy_count=0;
    float timer;
    int level;
    public GameObject parent;
    public GameObject boss_obj;
    public GameObject GM;
    public GameObject[] enemyPrefab;
    public GameObject[] eletePrefab;
    public GameObject[] bossPrefab;
    public float[] spawnTime = new float[5];

    private Player player;
    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        GM = GameObject.Find("DontDestroyOnLoad").transform.GetChild(1).transform.GetChild(0).gameObject;
        player = GM.GetComponent<GameManager>().player;
        for(int i = 0; i < 5; i++)
        {
            spawnTime[i] = (float)1 / (i + 1);
        }
    }
    void Update()
    {
        gameObject.transform.position = player.transform.position;
        timer += Time.deltaTime;
        level = Mathf.FloorToInt(GameManager.instance.Timer.GetComponent<Timer_Manager>().GameTime_H / 6f);
        if (GameManager.instance.bossnum != 6)
        {
            if (timer > spawnTime[level])
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
        if (GameManager.instance.bossnum == 6)
        {
            GameObject boss = Instantiate(bossPrefab[1], spawnPoint[spawnPoint.Length - 1].position, Quaternion.identity, transform);
            boss.transform.SetParent(boss_obj.transform);
        }
        else
        {
            GameObject boss = Instantiate(bossPrefab[0], spawnPoint[spawnPoint.Length - 1].position, Quaternion.identity, transform);
            boss.transform.SetParent(boss_obj.transform);
        }
    }
}
