using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer_Snack : MonoBehaviour
{
    public float dmg;

    public void OnTriggerStay2D(Collider2D other) {
        if(other.CompareTag("Enemy") || other.CompareTag("Boss")){
            //LV = Data.GetComponent<DataManager>().skill[5].Level;
            //dmg = 15 + 5 *(LV-1);
            other.GetComponent<Enemy>().GetDamage(dmg);
            Debug.Log(dmg);
        }
    }
}
