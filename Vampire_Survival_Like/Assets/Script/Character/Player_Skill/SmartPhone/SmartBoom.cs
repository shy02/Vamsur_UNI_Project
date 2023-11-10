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
    
    
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")||other.CompareTag("Boss")){
            LV = Data.GetComponent<DataManager>().skill[5].Level;
            dmg = 15 + 3 *(LV-1);
            other.GetComponent<Enemy>().GetDamage(dmg);
            Debug.Log(dmg);
        }
    }
    
    void final(){
        Invoke("Erase", eraseTime);
        circle.enabled = true;
    }

    public void Erase(){
        GameObject eff = Instantiate(BombEff, gameObject.transform.position , gameObject.transform.rotation);
        Destroy(gameObject);
    }
}