using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SumkillEnemy : MonoBehaviour
{
    public int DeadEnemy;
    public Text Deadnum;
    
    void Start(){
        Deadnum = gameObject.GetComponent<Text>();
        for(int i = 0; i > DeadEnemy; i++){
            Deadnum.text = i.ToString();
        }
    }
}
