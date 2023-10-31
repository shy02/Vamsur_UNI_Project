using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Snake : MonoBehaviour
{
    Animator animator;

    Rigidbody2D target;
    Rigidbody2D rigid;

    public GameObject tail;

    public int boss_HP; //���� �ʱ� ü��
    public int current_boss_HP; // ���� ���� ü��
    float timer;
    float fog_time;
    float attack_time; //���� ������ Ÿ�̸�
    public float cooltime = 3; //���� ������

    bool isattack = false; //���� ����
    bool fog_area = false;

    int random_;
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        //�ִϸ��̼�
        animator = GetComponent<Animator>();
        animator.SetBool("isfirst", false);

        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�ð� ���
        timer += Time.deltaTime;
        attack_time += Time.deltaTime;
        if (fog_area == true)
        {
            fog_time += Time.deltaTime;
            if (fog_time > 3)
            {
                fog_area = false;
                fog_time = 0;
            }
        }

        //���� ����
        Vector2 director = target.position - rigid.position;
        Vector2 next = director.normalized * speed * Time.deltaTime;
        //���� �̵�
        rigid.MovePosition(rigid.position + next);
        //���� ����
        random_ = Random.Range(1, 4);
        //���� ��ġ
        Vector3 targer_3 = target.position;
        Vector3 tail_pos = targer_3 + Vector3.right * Random.Range(-3, 3) + Vector3.forward * Random.Range(-3, 3);
        if (attack_time >= cooltime && isattack == false && fog_area == false)
        {
            switch (random_)
            {
                case 1:
                case 2:
                    //���� ����
                    Instantiate(tail, tail_pos, Quaternion.identity, transform);
                    Debug.Log("TaiL");
                    attack_time = 0;
                    break;
                case 3:
                    //���Ȱ�
                    Debug.Log("FoG");
                    fog_area = true;
                    break;
            }
        }
    }
}
