using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitStage : MonoBehaviour
{
    public GameObject skillmanager;
    public GameObject Spawner;
    public GameObject timer;
    public GameObject enemy;
    public GameObject DDOL;
    public GameObject player;
    public GameObject GM;
    public bool firstStage;
    void Start()
    {
        DDOL = GameObject.Find("DontDestroyOnLoad");
        GM = DDOL.transform.GetChild(1).transform.GetChild(0).gameObject;
        skillmanager = DDOL.transform.GetChild(1).transform.GetChild(1).gameObject;
        timer = DDOL.transform.GetChild(2).transform.GetChild(2).gameObject;
        player = DDOL.transform.GetChild(0).gameObject;

        player.transform.position = new Vector3(0, 0, 0);
        GameManager.instance.Player_HP = 100f;
        timer.GetComponent<Timer_Manager>().Spawner_Boss = Spawner;
        DDOL.transform.GetChild(4).gameObject.SetActive(false);
        GameManager.instance.Enemy = enemy;

        if(firstStage){
        skillmanager.GetComponent<SkillManager>().StartUI();
        }
    }
}
