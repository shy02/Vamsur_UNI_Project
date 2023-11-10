using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrink : MonoBehaviour
{
    Player player;
    void Start(){
        player = GameManager.instance.player;
    }
    void Update(){
        transform.position = player.transform.position;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Enemy")){
        other.GetComponent<Enemy>().KnockBack();
        other.GetComponent<Enemy>().GetDamage(5f);
        }
        
    }
}