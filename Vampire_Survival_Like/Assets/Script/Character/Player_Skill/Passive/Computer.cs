using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    private float LV;
    public GameObject player;
    void Update()
    {
        LV = GameManager.instance.DataManager.GetComponent<DataManager>().skill[10].Level;
        player.GetComponent<Player_State>().CoolTime = (10f + 5f*(LV-1))/100f;
    }
}

