

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
    public int bossnum;
    public DataManager data;
    void Start(){
        data = GameObject.Find("Manager").transform.GetChild(2).GetComponent<DataManager>();
    }

    public void EraseBook(){
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            AudioManager.A_instance.PlaySfx(AudioManager.Sfx.book);
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
            AudioManager.A_instance.PlaySfx(AudioManager.Sfx.book);
            if (!isFinal)
            {
                NormalDamage();
            }
            else
            {
                finalDamage();
            }

            NumEnermy++;
            bossnum = GameManager.instance.bossnum;
            switch (bossnum)
            {

                case 1:
                    other.GetComponent<Collider2D>().gameObject.GetComponent<Boss1>().GetDamage(damage);
                    break;
                case 2:
                    other.GetComponent<Collider2D>().gameObject.GetComponent<Boss2>().GetDamage(damage);
                    break;
                case 3:
                    other.GetComponent<Collider2D>().gameObject.GetComponent<Boss3>().GetDamage(damage);
                    break;
                case 4:
                    other.GetComponent<Collider2D>().gameObject.GetComponent<Boss4>().GetDamage(damage);
                    break;
                case 5:
                    other.GetComponent<Collider2D>().gameObject.GetComponent<Boss50>().GetDamage(damage);
                    break;
                case 6:
                    other.GetComponent<Collider2D>().gameObject.GetComponent<Boss5>().GetDamage(damage);
                    break;
                default:
                    break;
            }
        }


        {

        }
    }
    void NormalDamage()
    {

        lv = data.skill[11].Level;
        damage = 15 + 5 * (lv - 1);   //수정 1->2개
        damage = damage + ((damage / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);
    }
    void finalDamage()
    {
        damage = 55;
        damage = damage + ((damage / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);

    }
}