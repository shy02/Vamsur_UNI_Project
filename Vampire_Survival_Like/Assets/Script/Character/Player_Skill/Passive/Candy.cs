using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    private float LV;
    public GameObject player;
    void Update()
    {
        LV = GameManager.instance.DataManager.GetComponent<DataManager>().skill[13].Level;
        player.GetComponent<Player_State>().GetEXP =30f+ 14f * (LV - 1);
    }
}

