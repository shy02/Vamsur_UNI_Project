using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogChew : MonoBehaviour
{private float LV;
    public GameObject player;
    void Update()
    {
        LV = GameManager.instance.DataManager.GetComponent<DataManager>().skill[15].Level;
        player.GetComponent<Player_State>().WeaphoneTime = (10f + 5f*(LV-1))/100f;
    }
}
