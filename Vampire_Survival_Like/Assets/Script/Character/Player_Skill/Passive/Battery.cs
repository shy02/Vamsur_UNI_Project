using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    private float LV;
    public GameObject player;
    void Update()
    {
        LV = GameManager.instance.DataManager.GetComponent<DataManager>().skill[12].Level;
        player.GetComponent<Player_State>().ballSpeed = 5f+7.5f * (LV - 1);
    }
}


