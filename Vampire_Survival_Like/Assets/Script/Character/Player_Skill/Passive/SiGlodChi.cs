using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiGlodChi : MonoBehaviour
{
    private float LV;
    public GameObject player;
    void Update()
    {
        LV = GameManager.instance.DataManager.GetComponent<DataManager>().skill[9].Level;
        player.GetComponent<Player_State>().Force = 20 + 20f * (LV - 1);
    }
}
