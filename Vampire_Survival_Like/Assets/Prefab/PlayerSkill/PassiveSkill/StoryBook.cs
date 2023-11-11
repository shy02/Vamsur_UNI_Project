using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryBook : MonoBehaviour
{
    private float LV;
    public GameObject player;
    
    void Update()
    {
        LV = GameManager.instance.DataManager.GetComponent<DataManager>().skill[11].Level;
        player.GetComponent<Player_State>().BallCount = (int)(LV);
    }
}


//레벨값반