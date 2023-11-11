using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glove : MonoBehaviour
{
    private float LV;
    public GameObject player;
    void Update()
    {
        LV = GameManager.instance.DataManager.GetComponent<DataManager>().skill[8].Level;
        player.GetComponent<Player_State>().Attack_Speed = 6f * LV/100;
    }
}
