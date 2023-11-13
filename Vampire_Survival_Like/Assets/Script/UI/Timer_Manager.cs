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
        if(GameTime_H == 6 && !isBossdead){
            if (!Bossishere)
            {
                Spawner_Boss.GetComponent<Spawner>().Spawn_Boss();
                gameObject.GetComponent<Timer_Manager>().enabled = false;
                GameManager.instance.Enemy.SetActive(false);
                GM.GetComponent<GameManager>().OnBlock();
            }
            Bossishere = true;
            /*if(GameTime_sec > 30){
                GM.GetComponent<GameManager>().OffBlock();

                isBossdead = true;
            }*/
        }
        if (GameTime_H == 6 && isBossdead) {
            GM.GetComponent<GameManager>().OffBlock();
            isBossdead = false;
            Bossishere = false;
            bossnum += 1;
        }
        if (GameTime_H == 12 && !isBossdead)
        {
            if (!Bossishere)
            {
                if (!Spawner_Boss)
                {
                    Spawner_Boss.GetComponent<Spawner>().Spawn_Boss();
                    Bossishere = true;
                    gameObject.GetComponent<Timer_Manager>().enabled = false;
                    GameManager.instance.Enemy.SetActive(false);
                }
            }
            GM.GetComponent<GameManager>().OnBlock();
        }
        GameTime_sec += Time.deltaTime;
        if(GameTime_sec >= 60f){
            GameTime_H++;
            GameTime_sec = 0;
        }
        
        TimeText.text = string.Format("{0:D2}:{1:D2}",GameTime_H,(int)GameTime_sec);
        
    }
}
