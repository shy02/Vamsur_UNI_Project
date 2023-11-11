using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    SpriteRenderer spriter;

    Rigidbody2D target;
    Rigidbody2D bossPos;
    Rigidbody2D rigid;

    public Transform[] L_Point; // 쫄몹 생성위치
    public BoxCollider2D area; // 근접 공격 범위

    public GameObject s_bullet;
    public GameObject Enemy_L;

    public int boss_HP; // 보스 초기 체력
    public int current_boss_HP; // 보스 현재 체력
    float timer;
    public float spawn_police_time; // 쫄몹 생성 시간
    float attack_time; // 
    bool isattack = false; // 공격 여부
    public float attack_range = 7; // 공격 범위
    
    public float speed = 3;
    public GameObject GM;

    // Start is called before the first frame update
    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();


        L_Point = GetComponentsInChildren<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        bossPos = GetComponent<Rigidbody2D>();
        GM = GameObject.Find("Manager").transform.GetChild(0).gameObject;

        boss_HP = 200;
        current_boss_HP = boss_HP;
        area.enabled = false; // 공격 범위 비활성화
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if(boss_HP <= 0){
            GM.GetComponent<GameManager>().Survied();
        }
        timer += Time.deltaTime;
        spawn_police_time += Time.deltaTime;
        attack_time += Time.deltaTime;

        //보스 이동
        Vector2 director = target.position - rigid.position;
        if (Vector3.Distance(transform.position, target.position) > 7)
        {
            Vector2 next = director.normalized * speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + next);
        }

        //공격범위 이동
        transform.GetChild(2).localPosition = director.normalized;

        //플레이어와의 거리
        float distance = Vector3.Distance(transform.position, target.position); 

        //공격
        if (attack_time >= 3 && isattack == false)
        {
            if (distance <= attack_range)
            {
                //근접 공격
                isattack = true;
                Debug.Log("melle attack");
                StopCoroutine("atk_area"); //코루틴 함수로 공격범위 제어
                StartCoroutine("atk_area");
            }
            else if (distance > attack_range)
            {
                //스턴건 공격
                isattack = true;
                Debug.Log("stungun attack");
                Instantiate(s_bullet, bossPos.position, Quaternion.identity);
            }

            if (spawn_police_time >= 20)
            {
                //쫄몹 소환
                isattack = true;
                Instantiate(Enemy_L, L_Point[1].position, Quaternion.identity);
                Instantiate(Enemy_L, L_Point[2].position, Quaternion.identity);
                spawn_police_time = 0;
            }
            attack_time = 0;
            isattack = false;
        }
    }

    IEnumerator atk_area()
    {
        area.enabled = true; // 공격범위 활성화
        yield return new WaitForSeconds(2f); // 2초후 비활성화
        area.enabled = false;
    }

    private void LateUpdate()
    {
        spriter.flipX = target.position.x < rigid.position.x;
    }
}
