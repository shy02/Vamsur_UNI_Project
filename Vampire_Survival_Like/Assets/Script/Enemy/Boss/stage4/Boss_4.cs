using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_4 : MonoBehaviour
{

    Rigidbody2D target;
    SpriteRenderer spriter;
    Rigidbody2D rigid;

    public BoxCollider2D area; // 근접 공격 범위
    public Transform[] L_Point; // 쫄몹 생성위치
    public GameObject spawnMob;
    public GameObject bullet;
    public GameObject fog;



    public float fog_time = 0;
    public float cool_time;
    float speed = 1;
    public int fog_count = 0;
    public int random_;
    public float distance;
    public int i_distance;
    public float boss_HP = 300;
    public float current_boss_HP;

    public bool is_fog;
    public bool rnd_use;

    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        is_fog = false;
        rnd_use = true;
        fog.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //공격 쿨타임 조정
        distance = Vector3.Distance(transform.position, target.position);
        i_distance = (int)distance;
        //공격 패턴 랜덤 함수
        if (rnd_use == true)
        {
            random_ = Random.Range(1, 3);
            rnd_use = false;
        }
        // 연막탄 공격을 하지 않고 쿨타임이 2초 지났을때
        if (is_fog == false)
        {
            cool_time += Time.deltaTime;
            if (fog_count < 5)
            {
                switch (random_)
                {
                    case 1:
                        //근접 공격
                        if (cool_time > 5)
                        {
                            Debug.Log("근접 성공");
                            fog_count += 1;
                            rnd_use = true;
                            StopCoroutine("atk_area"); //코루틴 함수로 공격범위 제어
                            StartCoroutine("atk_area");
                            cool_time = 0;
                            break;
                        }
                        if (distance < 0) //너무 근접했을때 도망
                        {
                            moving(-1);
                        }
                        else if (distance > 2) // 거리가 멀어서 접근
                        {
                            Debug.Log("근접 실패");
                            if (cool_time < 5)
                            {
                                moving(1.2f);
                            }
                            else // 거리가 멀어서 빠른 접근
                            {
                                moving(1.4f);
                            }
                        }
                        else if(i_distance == 1)
                        {
                            Debug.Log("근접 실패 - 거리 맞음");
                        }
                        break;
                    case 2:
                        //원거리 공격
                        if (cool_time > 5)
                        {
                            Debug.Log("원거리 성공");
                            fog_count += 1;
                            rnd_use = true;
                            cool_time = 0;
                            Instantiate(bullet, rigid.position, Quaternion.identity);
                            break;
                        }
                        if (distance < 5) //너무 근접해서 도망
                        {
                            Debug.Log("원거리 실패");
                            moving(-1);
                        }
                        else if (distance > 6) //멀어서 근접
                        {
                            moving(1);
                        }
                        else if (i_distance == 5)
                        {
                            Debug.Log("원거리 실패 - 거리 맞음");
                        }
                        break;

                }
            }
            else if (fog_count >= 5)
            {
                //특수 기믹
                fog.SetActive(true);
                fog_count = 0;
                is_fog = true;
                Instantiate(spawnMob, L_Point[0].position, Quaternion.identity);
                Instantiate(spawnMob, L_Point[1].position, Quaternion.identity);
            }

        }
        else if (is_fog == true && fog_time < 5)
        {
            spriter.enabled = false;
            fog_time += Time.deltaTime;
            //애니메이션도 꺼야함 ㅇㅇ
        }
        else if (is_fog == true && fog_time > 5)
        {
            is_fog = false;
            spriter.enabled = true;
            fog_time = 0;
            fog.SetActive(false);
        }
    }

    private void moving(float value)
    {
        //이동 위치값 조정
        Vector2 director = target.position - rigid.position;
        Vector2 next = director.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + next * value);
        transform.GetChild(3).localPosition = director.normalized;
        Debug.Log("move");
    }

    IEnumerator atk_area()
    {
        area.enabled = true; // 공격범위 활성화
        yield return new WaitForSeconds(2f); // 2초후 비활성화
        area.enabled = false;
    }
    public void Boss_Damage(float dmg)
    {
        current_boss_HP = current_boss_HP - dmg;
    }
    private void LateUpdate()
    {
        spriter.flipX = target.position.x < rigid.position.x;
    }
}

