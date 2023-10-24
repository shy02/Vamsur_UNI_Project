using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy_Long : MonoBehaviour
{
    public GameObject Bullet;
    public Transform pos; //������ġ
    public Rigidbody2D target;

    //public float distance;
    public float speed; //�� �ӵ�
    public float atkDistance; //���� �Ÿ�
    public float cooltime; //���� �ӵ�
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
        //Ÿ�� ������ - �� ������ = �÷��̾�� ���ϴ� ����
        Vector2 director = target.position - rigid.position;

        //���� * �����ǵ� * �ð� = ������ �� ��ġ
        Vector2 next = director.normalized * speed * Time.fixedDeltaTime;

        //������ ������ ��ġ�� �����̱�
        if (director.magnitude > atkDistance) //director.magnitude = Ÿ�ٰ��� �Ÿ�
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
            //�������� �ӵ��� ���� ���������ǰ��� �浹 ���ֱ�
            rigid.velocity = Vector2.zero;
        }
    }
    void LateUpdate()
    {
        spriter.flipX = target.position.x > rigid.position.x;
    }
}
