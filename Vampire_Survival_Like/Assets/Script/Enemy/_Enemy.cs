using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Enemy : MonoBehaviour
{
    private float em_health = 100f;
    // Start is called before the first frame update
    public float speed;
    public float _speed;
    private GameObject gameManager;
    private Rigidbody2D target;
    bool isLive;

    SpriteRenderer spriter;
    Rigidbody2D rigid;

    void Start()
    {
        _speed = speed;
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager");
        target = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.collider.gameObject.CompareTag("Player")) {
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


        em_health -= collision.GetComponent<cbullet>().damage;

        if (em_health <= 0)
        {
            Dead();
        }

    }
    public void Dead()
    {
        Destroy(gameObject);
    }


    public void Slow()      //바나나밟으면 속도 감소 (추가)
    {

        speed *= 0.2f;
        Invoke("BackSpeed", 2f);
        }

    public void BackSpeed()
    {
        speed = _speed;
    }
    private void LateUpdate()
    {
        spriter.flipX = target.position.x > rigid.position.x;
    }


}
