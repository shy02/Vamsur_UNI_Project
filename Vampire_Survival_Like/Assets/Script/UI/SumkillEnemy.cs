using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SumkillEnemy : MonoBehaviour
{
    public int DeadEnemy = 0;
    public Text Deadnum;
    
    void Update(){
        DeadEnemy = GameManager.instance.DeadNum;
        Deadnum = gameObject.GetComponent<Text>();
            Deadnum.text = DeadEnemy.ToString();
        
    }
}
