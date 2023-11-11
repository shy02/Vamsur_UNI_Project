using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrink : MonoBehaviour
{
    Player player;
    private GameObject Data;
    private float dmg;
    private float lv;
    void Start(){
        player = GameManager.instance.player;
        Data = GameObject.Find("Manager").transform.GetChild(2).gameObject;
    }
    void Update(){
        transform.position = player.transform.position;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Enemy")){
        other.GetComponent<Enemy>().KnockBack();

        lv = Data.GetComponent<DataManager>().skill[1].Level;
        dmg = 11f + 5f*(lv-1);
        dmg = dmg + ((dmg / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);

        other.GetComponent<Enemy>().GetDamage(dmg);
        }
        
    }
}