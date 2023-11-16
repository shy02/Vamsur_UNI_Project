using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer_Manager : MonoBehaviour
{
    public float GameTime_sec = 0;
    public int GameTime_H = 0;
    public bool isBossdead = false;
    public Text TimeText;
    public GameObject Timer_UI;
    public GameObject GM;
    public GameObject Spawner;
    public int bossnum;
    int spawn_enemy;
    public bool Bossishere = false;
    
    void Start()
    {
        Timer_UI.SetActive(true);
        gameObject.GetComponent<Timer_Manager>().enabled = true;
        Bossishere = false;
        bossnum = 1;
    }
    // Update is called once per frameS
    void Update()
    {
        bossnum = GameManager.instance.bossnum;
        if (GameTime_H == 6 && !Bossishere && bossnum == 1)
        {
            spawnBoss();
        }

        if (GameTime_H == 12 && !Bossishere && bossnum == 2)
        {
            spawnBoss();
        }
        if (GameTime_H == 18 && !Bossishere && bossnum == 3)
        {
            spawnBoss();
        }
        if (GameTime_H == 24 && !Bossishere && bossnum == 4)
        {
            spawnBoss();
        }
        if (GameTime_H == 27 && !Bossishere && bossnum == 5)
        {
            spawnBoss();
        }
        if (GameTime_H == 30 && !Bossishere && bossnum == 6)
        {
            spawnBoss();
        }
        if (Bossishere)
        {
            spawn_enemy = GameManager.instance.Enemy.transform.childCount;
            for (int i = 0; i < spawn_enemy; i++)
            {
                Destroy(GameManager.instance.Enemy.transform.GetChild(i).gameObject);
            }
        }
        GameTime_sec += Time.deltaTime;
        if(GameTime_sec >= 60f){
            GameTime_H++;
            GameTime_sec = 0;
        }
        
        TimeText.text = string.Format("{0:D2}:{1:D2}",GameTime_H,(int)GameTime_sec);
        
    }
    void spawnBoss()
    {
        Spawner.GetComponent<Spawner>().Spawn_Boss();
        gameObject.GetComponent<Timer_Manager>().enabled = false;
        GameManager.instance.Enemy.SetActive(false);
        Spawner.SetActive(false);
        GM.GetComponent<GameManager>().OnBlock();
        Bossishere = true;
    }
}
