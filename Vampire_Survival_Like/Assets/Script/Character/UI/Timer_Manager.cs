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

    private bool Bossishere = false;
    
    void Start()
    {
        Timer_UI.SetActive(true);
        gameObject.GetComponent<Timer_Manager>().enabled = true;
        Bossishere = false;
    }
    // Update is called once per frameS
    void Update()
    {/*
        if(GameTime_H >= 5){
            gameObject.GetComponent<Timer_Manager>().enabled = false;
            Timer_UI.SetActive(false);
            GM.GetComponent<GameManager>().Survied();   
        }*/
        //1stage 보스 소환
        if(GameTime_H == 5 && !isBossdead&& GameManager.instance.stage==0){
            if (!Bossishere)
            {
                Spawner_Boss.GetComponent<Spawner>().Spawn_Boss(GameManager.instance.stage);
                Bossishere = true;
                GameManager.instance.Enemy.SetActive(false);
            }

            GM.GetComponent<GameManager>().OnBlock();
        }
        if(GameTime_H == 5 && isBossdead && Bossishere&&GameManager.instance.stage ==0)
        {
            isBossdead = false; 
            Bossishere = false;
            GameManager.instance.stage = 1;
            GM.GetComponent<GameManager>().OffBlock();
            GameManager.instance.Enemy.SetActive(true);
        }
        //2stage 보스 소환
        if (GameTime_H == 10 && !isBossdead && GameManager.instance.stage == 1)
        {
            if (!Bossishere)
            {
                Spawner_Boss.GetComponent<Spawner>().Spawn_Boss(GameManager.instance.stage);
                Bossishere = true;
                GameManager.instance.Enemy.SetActive(false);
            }

            GM.GetComponent<GameManager>().OnBlock();
        }
        if (GameTime_H == 10 && isBossdead && Bossishere && GameManager.instance.stage == 1)
        {
            isBossdead = false;
            Bossishere = false;
            GameManager.instance.stage = 2;
            GM.GetComponent<GameManager>().OffBlock();
            GameManager.instance.Enemy.SetActive(true);
        }
        if (!Bossishere)
        {
            GameTime_sec += Time.deltaTime;
        }
        if(GameTime_sec >= 60f){
            GameTime_H++;
            GameTime_sec = 0;
        }
        TimeText.text = string.Format("{0:D2}:{1:D2}",GameTime_H,(int)GameTime_sec);
    }
}
