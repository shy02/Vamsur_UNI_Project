

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public float damage;
    public float lv;
    public int per;

    public DataManager data;
    void Start(){
        data = GameObject.Find("Manager").transform.GetChild(2).GetComponent<DataManager>();
    }

    void Update(){
        lv = data.skill[4].Level;
        damage = 10f + 4.25f*(lv-1f);
    }

    public void EraseBook(){
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            other.GetComponent<Enemy>().GetDamage(damage); 

        }
    }
}