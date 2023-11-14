using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    private float LV;
    
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject Data;

    void Update()
    {
            LV = Data.GetComponent<DataManager>().skill[10].Level;
                player.GetComponent<Player_State>().CoolTime = 10f + 5f * (LV - 1);
        }
    }

