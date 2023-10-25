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
    float currenttime;//시간 체크용

    SpriteRenderer spriter;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector2 director = target.position - rigid.position;//플레이어로 향하는 방향 = 타겟 포지션 - 몹 포지션
        Vector2 next = director.normalized * speed * Time.fixedDeltaTime; //다음에 갈 위치 = 방향 * 몹스피드 * 델타시간
       
        //다음에 가야할 위치로 움직이기
        if (director.magnitude > atkDistance) //director.magnitude = 타겟과의 거리 > 공격 사거리
        {
            rigid.MovePosition(rigid.position + next); // 타겟거리가 멀어서 가까이 이동
        }
        else if (director.magnitude <= atkDistance) //타겟과의 거리 <= 공격 사거리
        {
            if (currenttime >= cooltime) //쿨타임 >= 현재시간
            {
                Vector3 spawnPosition = transform.position;//bullet의 소환 위치를 정의하기 위해 ver3사용
                Instantiate(Bullet, spawnPosition, Quaternion.identity);//bullet 소환
                currenttime = 0;//시간 초기화
            }
            else if (currenttime < cooltime)
            {
                currenttime += Time.deltaTime;//델타시간 더하기
            }
            //물리적인 속도를 없애 무브포지션과의 충돌 없애기
            rigid.velocity = Vector2.zero;
        }
    }
    void LateUpdate()
    {
        spriter.flipX = target.position.x > rigid.position.x; //스프라이터를 플레이어 위치 x값보다 작다면 뒤집어라
    }
}
