using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_4 : MonoBehaviour
{

    Rigidbody2D target;
    SpriteRenderer spriter;
    Rigidbody2D rigid;

    float timer = 0;
    float speed = 5;

    bool is_fog;

    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        is_fog = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(is_fog == false)
        {

            Vector2 director = target.position - rigid.position;
            Vector2 next = director.normalized * speed * Time.deltaTime;

            float distance = Vector3.Distance(transform.position, target.position);


            if (distance < 1) // 1���� ����ﶧ
            {

            }
            else if (distance >= 1 && distance<4) // 1~4 �����϶� ���� ������ �������� (�� 1.2���)
            {
                rigid.MovePosition(rigid.position + next * 1.2f);
            }
            else if(distance >= 4) // 4���� �ֶ� ���Ÿ� ����
            {
                rigid.MovePosition(rigid.position + next);
            }
        }

        else if(is_fog == true && timer<5)
        {
            spriter.enabled = false;
            timer += Time.deltaTime;
        }
        else if(is_fog == true && timer > 5)
        {
                spriter.enabled = true;
        }
    }
}
