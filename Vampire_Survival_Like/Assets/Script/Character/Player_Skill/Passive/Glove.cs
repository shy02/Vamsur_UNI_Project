using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glove : MonoBehaviour
{
    
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject Data;
    private float LV;
    void Update()
    {
            LV = Data.GetComponent<DataManager>().skill[8].Level;
            player.GetComponent<Player_State>().itemGetArea = 10f+ 10f * (LV-1); //%
    }
}
