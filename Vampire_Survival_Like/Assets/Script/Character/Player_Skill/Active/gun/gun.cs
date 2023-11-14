using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage;
    public int per;//목표 적수
    public float speed;
    private int NumEnermy; // 죽인 적수
    private float timer;
    private GameObject Data;
    public GameObject TM;
    public float lv;
    public bool isFinal;
    public int bossnum;
    
    void Start(){
        Data = GameObject.Find("Manager").transform.GetChild(2).gameObject;
        TM = GameObject.Find("Timer");
    }

    public void Init(float damage, int per)//데미지와 탄수를 받아옴
    {
        this.damage = damage; // 데미지
        this.per = per; // 탄수 
    }

    void Update()
    {
        bossnum = TM.GetComponent<Timer_Manager>().bossnum;
        timer += Time.deltaTime;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if(per <= NumEnermy){
            Destroygun();
        }
        if(timer >= 2f){
            Destroygun();
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            if(!isFinal){
                NormalDamage();
            }
            else{
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
    }

    void Destroygun()
    {
        Destroy(gameObject);
    }

    void NormalDamage(){
        
            lv = Data.GetComponent<DataManager>().skill[0].Level;

            damage = 10f + 10f *(lv-1);
            damage = damage + ((damage / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);
    }
    void finalDamage(){
            damage = 60;
            damage = damage + ((damage / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);
     
    }
}
