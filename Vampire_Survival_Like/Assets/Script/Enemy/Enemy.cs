using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float em_health = 100f;
    // Start is called before the first frame update
    public float speed;
    private GameObject gameManager;
    private Rigidbody2D target;
    bool isLive;

    SpriteRenderer spriter;
    Rigidbody2D rigid;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager");
        target = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }
    
    private void OnCollisionStay2D(Collision2D other) {
        if(other.collider.gameObject.CompareTag("Player")){
            gameManager.GetComponent<GameManager>().Player_damage();
        }
    }
    void FixedUpdate()
    {
        Vector2 director = target.position - rigid.position;

        Vector2 next = director.normalized * speed * Time.fixedDeltaTime;

        rigid.MovePosition(rigid.position + next);

        rigid.velocity = Vector2.zero;
        target.velocity = Vector2.zero;

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
            return;


        em_health -= collision.GetComponent<Bullet>().damage;

        if(em_health <= 0)
        {
            Dead();
        }

    }
    void Dead()
    {
        Destroy(gameObject);
    }

    private void LateUpdate()
    {
        spriter.flipX = target.position.x > rigid.position.x;
    }
}
