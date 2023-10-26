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
    float currenttime;//�ð� üũ��

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
        
        Vector2 director = target.position - rigid.position;//�÷��̾�� ���ϴ� ���� = Ÿ�� ������ - �� ������
        Vector2 next = director.normalized * speed * Time.fixedDeltaTime; //������ �� ��ġ = ���� * �����ǵ� * ��Ÿ�ð�
       
        //������ ������ ��ġ�� �����̱�
        if (director.magnitude > atkDistance) //director.magnitude = Ÿ�ٰ��� �Ÿ� > ���� ��Ÿ�
        {
            rigid.MovePosition(rigid.position + next); // Ÿ�ٰŸ��� �־ ������ �̵�
        }
        else if (director.magnitude <= atkDistance) //Ÿ�ٰ��� �Ÿ� <= ���� ��Ÿ�
        {
            if (currenttime >= cooltime) //��Ÿ�� >= ����ð�
            {
                Vector3 spawnPosition = transform.position;//bullet�� ��ȯ ��ġ�� �����ϱ� ���� ver3���
                Instantiate(Bullet, spawnPosition, Quaternion.identity);//bullet ��ȯ
                currenttime = 0;//�ð� �ʱ�ȭ
            }
            else if (currenttime < cooltime)
            {
                currenttime += Time.deltaTime;//��Ÿ�ð� ���ϱ�
            }
            //�������� �ӵ��� ���� ���������ǰ��� �浹 ���ֱ�
            rigid.velocity = Vector2.zero;
        }
    }
    void LateUpdate()
    {
        spriter.flipX = target.position.x > rigid.position.x; //���������͸� �÷��̾� ��ġ x������ �۴ٸ� �������
    }
}
