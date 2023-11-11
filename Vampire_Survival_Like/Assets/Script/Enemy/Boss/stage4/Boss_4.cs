using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_4 : MonoBehaviour
{

    Rigidbody2D target;
    SpriteRenderer spriter;
    Rigidbody2D rigid;

    public BoxCollider2D area; // ���� ���� ����
    public Transform[] L_Point; // �̸� ������ġ
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
        //���� ��Ÿ�� ����
        distance = Vector3.Distance(transform.position, target.position);
        i_distance = (int)distance;
        //���� ���� ���� �Լ�
        if (rnd_use == true)
        {
            random_ = Random.Range(1, 3);
            rnd_use = false;
        }
        // ����ź ������ ���� �ʰ� ��Ÿ���� 2�� ��������
        if (is_fog == false)
        {
            cool_time += Time.deltaTime;
            if (fog_count < 5)
            {
                switch (random_)
                {
                    case 1:
                        //���� ����
                        if (cool_time > 5)
                        {
                            Debug.Log("���� ����");
                            fog_count += 1;
                            rnd_use = true;
                            StopCoroutine("atk_area"); //�ڷ�ƾ �Լ��� ���ݹ��� ����
                            StartCoroutine("atk_area");
                            cool_time = 0;
                            break;
                        }
                        if (distance < 0) //�ʹ� ���������� ����
                        {
                            moving(-1);
                        }
                        else if (distance > 2) // �Ÿ��� �־ ����
                        {
                            Debug.Log("���� ����");
                            if (cool_time < 5)
                            {
                                moving(1.2f);
                            }
                            else // �Ÿ��� �־ ���� ����
                            {
                                moving(1.4f);
                            }
                        }
                        else if(i_distance == 1)
                        {
                            Debug.Log("���� ���� - �Ÿ� ����");
                        }
                        break;
                    case 2:
                        //���Ÿ� ����
                        if (cool_time > 5)
                        {
                            Debug.Log("���Ÿ� ����");
                            fog_count += 1;
                            rnd_use = true;
                            cool_time = 0;
                            Instantiate(bullet, rigid.position, Quaternion.identity);
                            break;
                        }
                        if (distance < 5) //�ʹ� �����ؼ� ����
                        {
                            Debug.Log("���Ÿ� ����");
                            moving(-1);
                        }
                        else if (distance > 6) //�־ ����
                        {
                            moving(1);
                        }
                        else if (i_distance == 5)
                        {
                            Debug.Log("���Ÿ� ���� - �Ÿ� ����");
                        }
                        break;

                }
            }
            else if (fog_count >= 5)
            {
                //Ư�� ���
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
            //�ִϸ��̼ǵ� ������ ����
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
        //�̵� ��ġ�� ����
        Vector2 director = target.position - rigid.position;
        Vector2 next = director.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + next * value);
        transform.GetChild(3).localPosition = director.normalized;
        Debug.Log("move");
    }

    IEnumerator atk_area()
    {
        area.enabled = true; // ���ݹ��� Ȱ��ȭ
        yield return new WaitForSeconds(2f); // 2���� ��Ȱ��ȭ
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

