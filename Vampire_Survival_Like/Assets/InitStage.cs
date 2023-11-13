using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitStage : MonoBehaviour
{
    public GameObject skillmanager;
    void Start()
    {
        skillmanager = GameObject.Find("DontDestroyOnLoad").transform.GetChild(1).transform.GetChild(1).gameObject;
        GameManager.instance.Player_HP = 100f;

        skillmanager.GetComponent<SkillManager>().createUI();
    }
}
