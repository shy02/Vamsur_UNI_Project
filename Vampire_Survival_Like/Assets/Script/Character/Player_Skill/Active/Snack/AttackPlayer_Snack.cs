using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer_Snack : MonoBehaviour
{
    public float dmg;
    private GameObject Data;
    private float LV;
    public bool isFinal;
    public float damage;
    private int NumEnermy; // 죽인 적수
    private int per;
    private int num;
    private float curtime;
    private float cooltime;
    private int ballcount;
    public int bossnum;
    void Start()
    {

        Data = GameObject.Find("Manager").transform.GetChild(2).gameObject;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            AudioManager.A_instance.PlaySfx(AudioManager.Sfx.gun);
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
            AudioManager.A_instance.PlaySfx(AudioManager.Sfx.gun);
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
    }



    //LV = Data.GetComponent<DataManager>().skill[6].Level;

    //        dmg = 15f + 5f *(LV-1);
    //        dmg = dmg + ((dmg / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);

    //        other.GetComponent<Enemy>().GetDamage(dmg);
    //        Debug.Log(dmg);



void NormalDamage()
{

    LV = Data.GetComponent<DataManager>().skill[0].Level;

    dmg = 20f + 20f * (LV - 1);
    dmg = dmg + ((dmg / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);
}
void finalDamage()
{
    dmg = 65;
    dmg = dmg + ((dmg / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);

}
}

   
    //void SkillSet(float lv)
    //{

    //    dmg = 6.5f + 1.5f * (lv - 1);
    //    switch (lv)
    //    {//투사체 수
    //        case 1:
    //        case 2:
    //            num = 1;
    //            break;
    //        case 3:
    //        case 4:
    //            num = 2;
    //            break;
    //        case 5:
    //            num = 3;
    //            break;
    //        case 6:
    //            num = 4;
    //            break;
    //        case 7:
    //            num = 5;
    //            break;
    //        case 8:
    //            num = 6;
    //            break;
    //    }
    //    switch (lv)
    //    {//관통
    //        case 1:
    //        case 2:
    //        case 3:
    //            per = 1;
    //            break;
    //        case 4:
    //        case 5:
    //        case 6:
    //            per = 2;
    //            break;
    //        case 7:
    //        case 8:
    //            per = 3;
    //            break;
    //    }
    //}


