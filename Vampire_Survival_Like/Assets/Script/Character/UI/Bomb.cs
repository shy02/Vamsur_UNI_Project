using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public List<Sprite> img = new List<Sprite>(new Sprite[3]);
    public float stepTime;
    public float eraseTime;
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
        

        Invoke("secondstep", stepTime);

        Invoke("thirdstep",stepTime*2);
        Invoke("final",stepTime*3);
    }
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy") || other.CompareTag("Boss")){
            other.GetComponent<_Enemy>().Dead();
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
