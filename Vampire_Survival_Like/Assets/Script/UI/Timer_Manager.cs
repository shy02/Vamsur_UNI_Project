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
    public GameObject Spawner_Boss;
    public int bossnum;
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
            Spawner_Boss.GetComponent<Spawner>().Spawn_Boss();
            gameObject.GetComponent<Timer_Manager>().enabled = false;
            GameManager.instance.Enemy.SetActive(false);
            GM.GetComponent<GameManager>().OnBlock();
            Bossishere = true;
        }

        if (GameTime_H == 12 && !Bossishere && bossnum == 2)
        {
            Spawner_Boss.GetComponent<Spawner>().Spawn_Boss();
            Bossishere = true;
            gameObject.GetComponent<Timer_Manager>().enabled = false;
            GameManager.instance.Enemy.SetActive(false);
            GM.GetComponent<GameManager>().OnBlock();
            Bossishere = true;
        }
        if (GameTime_H == 18 && !Bossishere && bossnum == 3)
        {
            Spawner_Boss.GetComponent<Spawner>().Spawn_Boss();
            gameObject.GetComponent<Timer_Manager>().enabled = false;
            GameManager.instance.Enemy.SetActive(false);
            GM.GetComponent<GameManager>().OnBlock();
            Bossishere = true;
        }
        if (GameTime_H == 24 && !Bossishere && bossnum == 4)
        {
            Spawner_Boss.GetComponent<Spawner>().Spawn_Boss();
            gameObject.GetComponent<Timer_Manager>().enabled = false;
            GameManager.instance.Enemy.SetActive(false);
            GM.GetComponent<GameManager>().OnBlock();
            Bossishere = true;
        }
        if (GameTime_H == 27 && !Bossishere && bossnum == 5)
        {
            Spawner_Boss.GetComponent<Spawner>().Spawn_Boss();
            gameObject.GetComponent<Timer_Manager>().enabled = false;
            GameManager.instance.Enemy.SetActive(false);
            GM.GetComponent<GameManager>().OnBlock();
            Bossishere = true;
        }
        if (GameTime_H == 30 && !Bossishere && bossnum == 6)
        {
            Spawner_Boss.GetComponent<Spawner>().Spawn_Boss();
            gameObject.GetComponent<Timer_Manager>().enabled = false;
            GameManager.instance.Enemy.SetActive(false);
            GM.GetComponent<GameManager>().OnBlock();
            Bossishere = true;
        }
        GameTime_sec += Time.deltaTime;
        if(GameTime_sec >= 60f){
            GameTime_H++;
            GameTime_sec = 0;
        }
        
        TimeText.text = string.Format("{0:D2}:{1:D2}",GameTime_H,(int)GameTime_sec);
        
    }
}
