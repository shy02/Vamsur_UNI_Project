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
    public int bossnum;
    void Start()
    {
        player = GameManager.instance.player;
        Data = GameObject.Find("Manager").transform.GetChild(2).gameObject;
        AudioManager.A_instance.PlaySfx(AudioManager.Sfx.drink);
    }
    void Update()
    {
        transform.position = player.transform.position;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().KnockBack();
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

            switch (bossnum)
            {
                case 1:
                    other.GetComponent<Collider2D>().gameObject.GetComponent<Boss1>().GetDamage(dmg);
                    break;
                case 2:
                    other.GetComponent<Collider2D>().gameObject.GetComponent<Boss2>().GetDamage(dmg);
                    break;
                case 3:
                    other.GetComponent<Collider2D>().gameObject.GetComponent<Boss3>().GetDamage(dmg);
                    break;
                case 4:
                    other.GetComponent<Collider2D>().gameObject.GetComponent<Boss4>().GetDamage(dmg);
                    break;
                case 5:
                    other.GetComponent<Collider2D>().gameObject.GetComponent<Boss50>().GetDamage(dmg);
                    break;
                case 6:
                    other.GetComponent<Collider2D>().gameObject.GetComponent<Boss5>().GetDamage(dmg);
                    break;
                default:
                    break;
            }
        }


        lv = Data.GetComponent<DataManager>().skill[1].Level;
        dmg = 11f + 5f * (lv - 1);
        dmg = dmg + ((dmg / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);

        other.GetComponent<Enemy>().GetDamage(dmg);




        void NormalDamage()
        {

            lv = Data.GetComponent<DataManager>().skill[0].Level;

            dmg = 50f + 50f * (lv - 1);
            dmg = dmg + ((dmg / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);
        }
        void finalDamage()
        {
            dmg = 55;
            dmg = dmg + ((dmg / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);

        }
    }
}