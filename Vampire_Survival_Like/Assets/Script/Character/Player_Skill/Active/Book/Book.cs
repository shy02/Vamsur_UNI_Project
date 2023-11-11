

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public float damage;
    public float lv;
    public int per;
    public bool isFinal;
    private int NumEnermy; // 죽인 적수
    private GameObject Data;

    public DataManager data;
    void Start(){
        data = GameObject.Find("Manager").transform.GetChild(2).GetComponent<DataManager>();
    }

    void Update(){
    }

    public void EraseBook(){
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            if (!isFinal)
            {
                NormalDamage();
            }
            else
            {
                finalDamage();
            }

            NumEnermy++;
            other.GetComponent<Collider2D>().gameObject.GetComponent<Enemy>().GetDamage(damage);
        }
    




    //lv = data.skill[4].Level;
    //        damage = 10f + 4.25f*(lv-1f);
    //        damage = damage + ((damage / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);
            
            other.GetComponent<Enemy>().GetDamage(damage); 
        }
    void NormalDamage()
    {

        lv = Data.GetComponent<DataManager>().skill[11].Level;

        //damage = 15 + 5 * (lv - 1);
        //damage = damage + ((damage / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);
    }
    void finalDamage()
    {
        damage = 65;
        damage = damage + ((damage / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);

    }
}
