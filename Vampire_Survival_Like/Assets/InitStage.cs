using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitStage : MonoBehaviour
{
    public GameObject skillmanager;
    public GameObject Spawner;
    public GameObject timer;
    public GameObject enemy;
    void Start()
    {
        skillmanager = GameObject.Find("DontDestroyOnLoad").transform.GetChild(1).transform.GetChild(1).gameObject;
        timer = GameObject.Find("DontDestroyOnLoad").transform.GetChild(2).transform.GetChild(2).gameObject;

        GameManager.instance.Player_HP = 100f;
        timer.GetComponent<Timer_Manager>().Spawner_Boss = Spawner;
        GameManager.instance.Enemy = enemy;

        skillmanager.GetComponent<SkillManager>().createUI();
    }
}
