using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogChew : MonoBehaviour
{    
    private float LV;
    
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject Data;
    void Update()
    {
            LV = Data.GetComponent<DataManager>().skill[15].Level;
            player.GetComponent<Player_State>().WeaphoneTime = 10f + 5f*(LV-1);
    }
}
