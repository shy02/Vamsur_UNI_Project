using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Rigidbody2D target;
    bool isLive;

    SpriteRenderer spriter;
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }
    //FixedUpdate�� �������� �Ȱ��峪�� ���� Update.
    void FixedUpdate()
    {
        //Ÿ�� ������ - �� ������ = �÷��̾�� ���ϴ� ����
        Vector2 director = target.position - rigid.position;

        //���� * �����ǵ� * �ð� = ������ �� ��ġ
        Vector2 next = director.normalized * speed * Time.fixedDeltaTime;

        //������ ������ ��ġ�� �����̱�
        rigid.MovePosition(rigid.position + next);

        //�������� �ӵ��� ���� ���������ǰ��� �浹 ���ֱ�
        rigid.velocity = Vector2.zero;
        target.velocity = Vector2.zero;

    }
    //LateUpdate�� Update�� �ִ� �Լ��� ��� ���� �ڿ� ����.
    private void LateUpdate()
    {
        //Ÿ���� x��ġ�� ���� x��ġ���� �����ʿ� ���� �� ��������Ʈ ������.
        spriter.flipX = target.position.x > rigid.position.x;
    }
}
