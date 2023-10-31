using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public List<Sprite> img = new List<Sprite>(new Sprite[3]);
    public float stepTime;
    public float eraseTime;
    private float init_dmg = 90f;
    private float dmg = 90f;
    private float LV;
    private GameObject Data;
    public GameObject BombSp;
    BoxCollider2D box;
    SpriteRenderer SpRender;

    // Start is called before the first frame update
    void Start()
    {
        SpRender = GetComponent<SpriteRenderer>();
        BombSp = GameObject.Find("Manager").transform.GetChild(1).GetChild(0).gameObject;
        box = GetComponent<BoxCollider2D>();
        box.enabled = false;
        Data = GameObject.Find("Manager").transform.GetChild(2).gameObject;
        

        Invoke("secondstep", stepTime);

        Invoke("thirdstep",stepTime*2);
        Invoke("final",stepTime*3);
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy") || other.CompareTag("Boss")){
            LV = Data.GetComponent<DataManager>().skill[5].Level;
            dmg = init_dmg + LV/2;
            other.GetComponent<Enemy>().GetDamage(dmg);
            Debug.Log(dmg);
        }
    }

    void secondstep(){
        SpRender.sprite = img[1];
    }
    void thirdstep(){
        SpRender.sprite = img[2];
    }
    void final(){
        box.enabled=true;
        Invoke("Erase", eraseTime);
    }

    public void Erase(){
        BombSp.GetComponent<BobSpawner>().minusNum();
        Destroy(gameObject);
    }
}
