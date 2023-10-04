using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Pet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private float distance;
    public Rigidbody2D target;

    SpriteRenderer spriter;
    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
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
