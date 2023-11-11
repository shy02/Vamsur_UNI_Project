using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer_Snack : MonoBehaviour
{
    public float dmg;
    private GameObject Data;
    private float LV;

    void Start(){
        
        Data = GameObject.Find("Manager").transform.GetChild(2).gameObject;
    }

    public void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Enemy") || other.CompareTag("Boss")){
            LV = Data.GetComponent<DataManager>().skill[6].Level;
            
            dmg = 15f + 5f *(LV-1);
            dmg = dmg + ((dmg / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);
            
            other.GetComponent<Enemy>().GetDamage(dmg);
            Debug.Log(dmg);
        }
    }
}
