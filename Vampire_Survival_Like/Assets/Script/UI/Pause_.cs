using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_ : MonoBehaviour
{
<<<<<<< HEAD
    public bool nowPause;
    void Start()
    {
        nowPause = false;
=======
    public bool nowPause = true;
    void Start()
    {
>>>>>>> main
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
