using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  
    void Update()
    {
        if (Input.GetButtonDown("Jump")){
            GameManger.instance.pool.Get(1);
        }
    }
}

     