using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Pet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private float Player_Speed;
    public float distance;
    public float Distance_Gap;
    public GameObject Player;
    public GameObject Pet;
    public Rigidbody2D target;
    private Vector2 director;
    private Vector2 next;

    SpriteRenderer spriter;
    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        Player_Speed = Player.GetComponent<Player>().GetPlayerSpeed(Player_Speed);
    }
    void FixedUpdate()
    {
        if(Vector2.Distance(Player.transform.position, Pet.transform.position) > distance){
            if(Vector2.Distance(Player.transform.position,Pet.transform.position) > distance + Distance_Gap){
                 Move(Player_Speed);
            }
            else{ Move(speed);
        }}
        rigid.velocity = Vector2.zero;
        target.velocity = Vector2.zero;
    }
    private void LateUpdate()
    {
        spriter.flipX = target.position.x < rigid.position.x;
    }

    public void Move(float speed){
        director = target.position - rigid.position;
        
        next = director.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + next);

    }
}
