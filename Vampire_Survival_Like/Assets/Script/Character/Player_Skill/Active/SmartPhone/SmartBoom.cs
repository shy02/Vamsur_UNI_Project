using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartBoom : MonoBehaviour
{
    public List<Sprite> img = new List<Sprite>(new Sprite[1]);
    public float stepTime;
    public float eraseTime;
    private float dmg;
    private float LV;
    private GameObject Data;
    public GameObject BombEff;
    public bool isFinal;
    private int NumEnermy; // 죽인 적수
    public int bossnum;
    CircleCollider2D circle;
        
    SpriteRenderer SpRender;

    // Start is called before the first frame update
    void Start()
    {
        SpRender = GetComponent<SpriteRenderer>();
        Data = GameObject.Find("Manager").transform.GetChild(2).gameObject;
        circle = GetComponent<CircleCollider2D>();
        circle.enabled = false;
        Invoke("final",stepTime*1);
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

    void Destroygun()
    {
        Destroy(gameObject);
    }

    void NormalDamage()
    {

        LV = Data.GetComponent<DataManager>().skill[0].Level;

        dmg = 30f + 14 * (LV - 1);
        dmg = dmg + ((dmg / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);
    }
    void finalDamage()
    {
        dmg = 60;
        dmg = dmg + ((dmg / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);

    }

    void final()
    {
        Invoke("Erase", eraseTime);
        circle.enabled = true;
    }

    public void Erase()
    {
        GameObject eff = Instantiate(BombEff, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }

}


        //LV = Data.GetComponent<DataManager>().skill[3].Level;
        //    dmg = 15f + 3f *(LV-1);
        //    dmg = dmg + ((dmg / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);

        //    other.GetComponent<Enemy>().GetDamage(dmg);
        //    Debug.Log(dmg);
        
    
  
   