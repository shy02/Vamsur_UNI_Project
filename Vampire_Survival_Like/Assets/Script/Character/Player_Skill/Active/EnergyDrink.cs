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
    public int stage;
    void Start() {
        player = GameManager.instance.player;
        Data = GameObject.Find("Manager").transform.GetChild(2).gameObject;
    }
    void Update() {
        transform.position = player.transform.position;
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
            other.GetComponent<Collider2D>().gameObject.GetComponent<Enemy>().GetDamage(dmg);
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
            other.GetComponent<Collider2D>().gameObject.GetComponent<Enemy>().GetDamage(dmg);
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
        other.GetComponent<Enemy>().KnockBack();

        lv = Data.GetComponent<DataManager>().skill[1].Level;
        dmg = 11f + 5f * (lv - 1);
        dmg = dmg + ((dmg / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);

        other.GetComponent<Enemy>().GetDamage(dmg);
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