using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrink : MonoBehaviour
{
    Player player;
    private GameObject Data;
    private float dmg;
    private float lv;
    public bool isFinal;
    public float damage;
    private int NumEnermy;

    void Start(){
        player = GameManager.instance.player;
        Data = GameObject.Find("Manager").transform.GetChild(2).gameObject;
    }
    void Update(){
        transform.position = player.transform.position;
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
      
 
    other.GetComponent<Enemy>().KnockBack();

        lv = Data.GetComponent<DataManager>().skill[1].Level;
        dmg = 11f + 5f*(lv-1);
        dmg = dmg + ((dmg / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);

        other.GetComponent<Enemy>().GetDamage(dmg);
        }
        
    }

    void NormalDamage()
    {

        lv = Data.GetComponent<DataManager>().skill[1].Level;

        damage = 50 +50 * (lv - 1);
        damage = damage + ((damage / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);
    }
    void finalDamage()
    {
        damage = 55;
        damage = damage + ((damage / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);

    }
}