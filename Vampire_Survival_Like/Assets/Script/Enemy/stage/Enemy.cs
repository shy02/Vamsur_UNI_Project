using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage;
    private float HP = 100f;
    private float Current_HP;
    public float speed = 2;
    // private GameObject gameManager;
    //bool isLive;
    public GameObject Drop_exp;
    private Rigidbody2D target;
    SpriteRenderer spriter;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        Current_HP = HP;
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        if (Current_HP < 0.2f)
        {
            Dead();
        }
        Vector2 director = target.position - rigid.position;
        Vector2 next = director.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + next);

        rigid.velocity = Vector2.zero;
        target.velocity = Vector2.zero;
        spriter.flipX = target.position.x > rigid.position.x;

    }
    public void Enemy_Damage(float dmg)
    {
        Current_HP = Current_HP - dmg;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.gameObject.CompareTag("Player"))
        {
            GameManager.instance.Player_damage(damage);
        }
    }
    public void Dead()
    {
        Destroy(gameObject);
        Drop_Exp();
    }

    private void Drop_Exp()
    {
        Vector3 spawnPosition = transform.position;
        Debug.Log(spawnPosition);
        Instantiate(Drop_exp, spawnPosition, Quaternion.identity);
    }

    private void LateUpdate()
    {
        //spriter.flipX = target.position.x < rigid.position.x;
    }
}
