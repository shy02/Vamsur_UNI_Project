using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float em_health = 100f;
    // Start is called before the first frame update
    public float speed = 2;
    public float _speed;
    private GameObject gameManager;
    private Rigidbody2D target;
    bool isLive;
    public GameObject Drop_exp;

    SpriteRenderer spriter;
    Rigidbody2D rigid;
    
    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        _speed = speed;
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager");
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
        
        if(em_health <= 0)
        {
            Dead();
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet")) return;
    }

    public void Dead()
    {
        Destroy(gameObject);
        Debug.Log("죽어버림");
        Drop_Exp();
    }
    public void GetDamage(float DMG){
        Debug.Log("데미지 받았따");
        em_health = em_health - DMG;
    }

    private void Drop_Exp()
    {
        Vector3 spawnPosition = transform.position;
        Instantiate(Drop_exp, spawnPosition, Quaternion.identity);
    }

    private void LateUpdate()
    {
        spriter.flipX = target.position.x > rigid.position.x;
    }

    public void Slow(float slowFactor)      //바나나밟으면 속도 감소 (추가)
    {

        speed *= (slowFactor/100);
        Invoke("BackSpeed", 2f);
        }

    public void BackSpeed()
    {
        speed = _speed;
    }
}
