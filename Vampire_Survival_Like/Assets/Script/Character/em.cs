using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class em : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    public float speed;
    public Rigidbody2D target;

    bool isLive;

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();

    }


    private void FixedUpdate()
    {
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
            return;


        health -= collision.GetComponent<Bullet>().damage;

        if(health > 0)
        {
            
        }
        else
        {
            Dead();
        }

    }
    void Dead()
    {
        gameObject.SetActive(false);
    }
}

