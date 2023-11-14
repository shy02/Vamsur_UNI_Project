using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothes : MonoBehaviour
{
    private float LV;
    public GameObject player;
    void Update()
    {
        LV = GameManager.instance.DataManager.GetComponent<DataManager>().skill[8].Level;
        player.GetComponent<Player_State>().HP = 50f+ 50f * (LV - 1);
    }
}

