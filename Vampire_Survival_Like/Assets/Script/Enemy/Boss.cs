using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    SpriteRenderer spriter;
    Animator animator;

    Rigidbody2D target;
    Rigidbody2D bossPos;
    Rigidbody2D rigid;

    public Transform[] L_Point; //�̸� ��ȯ ��ġ
    public BoxCollider2D area; //���ݹ���

    public GameObject s_bullet;
    public GameObject Enemy_L;

    public int boss_HP; //���� �ʱ� ü��
    public int current_boss_HP; // ���� ���� ü��
    float timer;
    public float spawn_police_time; //�̸� ��ȯ �ð�
    float attack_time; //���� ������
    bool isattack = false; //���� ����
    public float attack_range = 7; //���� ����
    
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        //animator.SetBool("isfirst", false);
        spriter = GetComponent<SpriteRenderer>();


        L_Point = GetComponentsInChildren<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        bossPos = GetComponent<Rigidbody2D>();

        boss_HP = 200;
        current_boss_HP = boss_HP;
        area.enabled = false; // ���ݹ��� ��Ȱ��ȭ
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        spawn_police_time += Time.deltaTime;
        attack_time += Time.deltaTime;

        //�����̵�
        if (Vector3.Distance(transform.position, target.position) > 7)
        {
            Vector2 director = target.position - rigid.position;

            Vector2 next = director.normalized * speed * Time.fixedDeltaTime;

            rigid.MovePosition(rigid.position + next);
        }

// ���ݹ��� �̵�
        /*transform.GetChild(2).localPosition = director.normalized; 

        if (timer > 1)
        {
            animator.SetBool("isfirst", false);
        }*/
       

        //�÷��̾���� �Ÿ�
        float distance = Vector3.Distance(transform.position, target.position); 

        if (attack_time >= 3 && isattack == false)
        {
            if (distance <= attack_range)
            {
                //��������
                isattack = true;
                Debug.Log("melle attack");
                StopCoroutine("atk_area"); //�ڷ�ƾ �Լ�
                StartCoroutine("atk_area");
            }
            else if (distance > attack_range)
            {
                //���ϰ� ����
                isattack = true;
                Debug.Log("stungun attack");
                Instantiate(s_bullet, bossPos.position, Quaternion.identity);
            }

            if (spawn_police_time >= 20)
            {
                //��� ��ȯ
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
        area.enabled = true; // ���� ���� Ȱ��ȭ
        yield return new WaitForSeconds(2f); // 2���� ��Ȱ��ȭ
        area.enabled = false;
    }
    private void LateUpdate()
    {
        spriter.flipX = target.position.x < rigid.position.x;
    }
}
