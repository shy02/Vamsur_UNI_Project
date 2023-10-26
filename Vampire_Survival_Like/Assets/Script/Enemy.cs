using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float enemyHP;
    public float enemy_maxHP;
    public Rigidbody2D target;
    bool isLive;
    public GameObject Drop_exp;

    SpriteRenderer spriter;
    Rigidbody2D rigid;

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        enemyHP = enemy_maxHP;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }
    //FixedUpdate는 물리엔진 안고장나게 쓰는 Update.
    void FixedUpdate()
    {
        //타겟 포지션 - 몹 포지션 = 플레이어로 향하는 방향
        Vector2 director = target.position - rigid.position;

        //방향 * 몹스피드 * 시간 = 다음에 갈 위치
        Vector2 next = director.normalized * speed * Time.fixedDeltaTime;

        //다음에 가야할 위치로 움직이기
        rigid.MovePosition(rigid.position + next);

        //물리적인 속도를 없애 무브포지션과의 충돌 없애기
        rigid.velocity = Vector2.zero;

    }
    //LateUpdate는 Update에 있는 함수가 모두 끝난 뒤에 실행.
    private void LateUpdate()
    {
        //타겟의 x위치가 몹의 x위치보다 오른쪽에 있을 때 스프라이트 뒤집기.
        spriter.flipX = target.position.x > rigid.position.x;
    }

    private void OnDestroy()
    {
      Vector3 spawnPosition = transform.position;//bullet의 소환 위치를 정의하기 위해 ver3사용
      Debug.Log(spawnPosition);
      Instantiate(Drop_exp, spawnPosition, Quaternion.identity);
    }
}