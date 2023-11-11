using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Find_Enermy : MonoBehaviour
{
    public float rad = 0f;
    public LayerMask layer;
    public Collider2D[] colls;
    public Collider2D short_enemy;
    public float Speed;
    public float timer;
    public GameObject player;
    public float dmg;
    public Animator Poppy_anime;
    private GameObject Data;
    public bool isFinal;
    private int NumEnermy; // 죽인 적수
    public float lv;

    void Start()
    {
        Poppy_anime = GetComponent<Animator>();
        Data = GameObject.Find("Manager").transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        colls = Physics2D.OverlapCircleAll(transform.position, rad, layer);

        if(colls.Length > 0)
        {
            float short_distance = Vector3.Distance(transform.position, colls[0].transform.position);
            foreach(Collider2D col in colls)
            {
                float short_distance2 = Vector3.Distance(transform.position, col.transform.position);
                if(short_distance > short_distance2){
                    short_distance = short_distance2;
                    short_enemy = col;
                }
            }
        }
        if(timer >= 3f){
        if(short_enemy){
            Attack();
        }
        else{
            gameObject.GetComponent<Move_Pet>().enabled = true;
        }
        }
    }

    private void Attack(){
            Poppy_anime.SetBool("isMove", true);
            gameObject.GetComponent<Move_Pet>().enabled = false;
            gameObject.transform.position = Vector3.MoveTowards(transform.position, short_enemy.gameObject.transform.position, Speed * Time.deltaTime);
            if(timer >= 6f){
                timer = 0;
                Return();
            }
    }

    private void Return(){
        Poppy_anime.SetBool("isMove", false);
        gameObject.transform.position = player.transform.position;
        gameObject.GetComponent<Move_Pet>().enabled = true;
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rad);
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
            other.GetComponent<Collider2D>().gameObject.GetComponent<Enemy>().GetDamage(dmg);
        }

        //dmg = dmg + ((dmg / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);
        //    other.gameObject.GetComponent<Enemy>().GetDamage(dmg);
        
    }

    void NormalDamage()
    {

        lv = Data.GetComponent<DataManager>().skill[14].Level;

        dmg = (10f + 5f * (lv - 1)) / 100f;
        dmg =  dmg = + ((dmg  / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);
    }
    void finalDamage()
    {
        dmg =  60;
        dmg =  dmg = + ((dmg / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);

    }
}
