using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public GameObject gameManager;
    public Rigidbody2D target;
    bool isLive;

    SpriteRenderer spriter;
    Rigidbody2D rigid;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
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
    
    private void LateUpdate()
    {
        spriter.flipX = target.position.x > rigid.position.x;
    }
}
