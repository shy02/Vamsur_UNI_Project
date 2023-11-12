using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_ : MonoBehaviour
{
    public bool nowPause = true;
    void Start()
    {
    }
       public void Pause () {
        if(nowPause == false){
            Time.timeScale = 0;
            nowPause = true;
            return;
        }
        if(nowPause == true){
            Time.timeScale = 1;
            nowPause = false;
            return;
        }
    }
}
