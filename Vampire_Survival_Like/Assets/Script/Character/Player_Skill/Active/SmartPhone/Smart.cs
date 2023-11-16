using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smart : MonoBehaviour
{
    public float damage;
    public int per;//목표 적수
    public float speed;
    private int NumEnermy; // 죽인 적수
    private float timer;
    private float lv;
    public int bossnum;
    private GameObject Data;
    

    public void Init(float damage, int per)//데미지와 탄수를 받아옴
    {
        this.damage = damage; // 데미지
        this.per = per; // 탄수
        
    }

void Start(){
        Data = GameObject.Find("Manager").transform.GetChild(2).gameObject;
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
            lv = Data.GetComponent<DataManager>().skill[3].Level;

            damage = 10f + 5.1f*(lv-1);
            damage = damage + ((damage / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);
            NumEnermy++;
            other.GetComponent<Collider2D>().gameObject.GetComponent<Enemy>().GetDamage(damage);
        }
    }

    void Destroygun()
    {
        Destroy(gameObject);
    }
    
    
}
