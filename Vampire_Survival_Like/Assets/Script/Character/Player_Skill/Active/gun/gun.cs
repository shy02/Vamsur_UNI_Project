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
    public float lv;
    public bool isFinal;
    
    void Start(){
        Data = GameObject.Find("Manager").transform.GetChild(2).gameObject;
    }

    public void Init(float damage, int per)//데미지와 탄수를 받아옴
    {
        this.damage = damage; // 데미지
        this.per = per; // 탄수 
    }

    void Update()
    {
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
        if(other.CompareTag("Enemy")||other.CompareTag("Boss")){
            if(!isFinal){
                NormalDamage();
            }
            else{
                finalDamage();
            }
            NumEnermy++;
            other.GetComponent<Collider2D>().gameObject.GetComponent<Enemy>().GetDamage(damage);
        }
    }

    void Destroygun()
    {
        Destroy(gameObject);
    }

    void NormalDamage(){
        
            lv = Data.GetComponent<DataManager>().skill[0].Level;

            damage = 15 + 5 *(lv-1);
            damage = damage + ((damage / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);
    }
    void finalDamage(){
            damage = 60;
            damage = damage + ((damage / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);
     
    }
}
