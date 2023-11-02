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
    int stage;
    
    void Start()
    {
        Timer_UI.SetActive(true);
        gameObject.GetComponent<Timer_Manager>().enabled = true;
        Bossishere = false;
        stage=1;
    }
    // Update is called once per frameS
    void Update()
    {
        /*if(GameTime_H >= 5){
            gameObject.GetComponent<Timer_Manager>().enabled = false;
            Timer_UI.SetActive(false);
            GM.GetComponent<GameManager>().Survied();   
        }*/
        if(GameTime_H == 5 && !isBossdead){
            if (!Bossishere)
            {
                Spawner_Boss.GetComponent<Spawner>().Spawn_Boss(stage);
                Bossishere = true;
                gameObject.GetComponent<Timer_Manager>().enabled=false;
                GameManager.instance.Enemy.SetActive(false);
            }

            GM.GetComponent<GameManager>().OnBlock();
            if(GameTime_sec > 30){
                GM.GetComponent<GameManager>().OffBlock();

                isBossdead = true;
            }
        }
        
        

        if (GameTime_H == 5 && isBossdead) { isBossdead = false; Bossishere = false; }
        GameTime_sec += Time.deltaTime;
        if(GameTime_sec >= 60f){
            GameTime_H++;
            GameTime_sec = 0;
        }
        
        TimeText.text = string.Format("{0:D2}:{1:D2}",GameTime_H,(int)GameTime_sec);
        
    }
}
