

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
    public int stage;
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
        if (other.CompareTag("Enemy"))
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

        if (other.CompareTag("Boss"))
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
        switch (stage)
        {

            case 1:
                other.GetComponent<Collider2D>().gameObject.GetComponent<Boss1>().GetDamage(Damage);
                break;

            case 2:
                other.GetComponent<Collider2D>().gameObject.GetComponent<Boss2>().GetDamage(Damage);
                break;

            case 3:
                other.GetComponent<Collider2D>().gameObject.GetComponent<Boss3>().GetDamage(Damage);
                break;

            case 4:
                other.GetComponent<Collider2D>().gameObject.GetComponent<Boss4>().GetDamage(Damage);
                break;

            case 5:
                other.GetComponent<Collider2D>().gameObject.GetComponent<Boss50>().GetDamage(Damage);
                break;

            case 6:
                other.GetComponent<Collider2D>().gameObject.GetComponent<Boss5>().GetDamage(Damage);
                break;


            default:

                break;
        }


        {

        }
    }
        void NormalDamage()
    {

        lv = data.skill[11].Level;
        damage = 15 + 5 * (lv - 1);
        damage = damage + ((damage / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);
    }
    void finalDamage()
    {
        damage = 65;
        damage = damage + ((damage / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);

    }
}
