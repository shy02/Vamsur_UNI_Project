using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy_Long : MonoBehaviour
{
    public GameObject Bullet;
    public Transform pos; //생성위치
    public Rigidbody2D target;

    //public float distance;
    public float speed; //몹 속도
    public float atkDistance; //공격 거리
    public float cooltime; //공격 속도
    float currenttime;

    SpriteRenderer spriter;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //타겟 포지션 - 몹 포지션 = 플레이어로 향하는 방향
        Vector2 director = target.position - rigid.position;

        //방향 * 몹스피드 * 시간 = 다음에 갈 위치
        Vector2 next = director.normalized * speed * Time.fixedDeltaTime;

        //다음에 가야할 위치로 움직이기
        if (director.magnitude > atkDistance) //director.magnitude = 타겟과의 거리
        {
            rigid.MovePosition(rigid.position + next);
        }
        else if (director.magnitude <= atkDistance)
        {
            if (currenttime >= cooltime)
            {
                Vector3 spawnPosition = transform.position;
                Instantiate(Bullet, spawnPosition, Quaternion.identity);
                currenttime = 0;
            }
            else if (currenttime < cooltime)
            {
                currenttime += Time.deltaTime;
            }
            //물리적인 속도를 없애 무브포지션과의 충돌 없애기
            rigid.velocity = Vector2.zero;
        }
    }
    void LateUpdate()
    {
        spriter.flipX = target.position.x > rigid.position.x;
    }
}
