using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dron_Cannon : MonoBehaviour
{
<<<<<<< HEAD:Vampire_Survival_Like/Assets/Script/Enemy/bullet.cs
    private float speed= 5000f; // �ӵ��� ����
    Rigidbody2D rigid, target;

    Transform playerPos;

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>(); //�÷��̾��� ������ ��������
    }

    // Start is called before the first frame update
    void Start()
    {    
        rigid = GetComponent<Rigidbody2D>();
        Vector2 director = target.position - rigid.position; //��ü �̵����� ����
        rigid.AddForce(rigid.position + director.normalized * speed * Time.fixedDeltaTime); //��ü �̵� (���� ��ġ + ����ȯ�� �̵����� * �ӵ��� * ��ŸŸ��
        rigid.velocity = Vector2.zero; //��ü �ӵ� = 0
        Destroy(gameObject, 10f);
=======
    // Start is called before the first frame update
    Rigidbody2D target,rigid;

    float speed = 20000f;

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        rigid = GetComponent<Rigidbody2D>();
        moveCannon();
        Destroy(gameObject, 2f);
>>>>>>> 639c65b06df45023916c3820b45abd55947ebe0c:Vampire_Survival_Like/Assets/Script/Enemy/Boss/stage5/Dron_Cannon.cs
    }

    // Update is called once per frame
    void FixedUpdate()
<<<<<<< HEAD:Vampire_Survival_Like/Assets/Script/Enemy/bullet.cs
    {/*
        Vector2 director = target.position - rigid.position; //��ü �̵����� ����
        rigid.MovePosition(rigid.position + director.normalized * speed * Time.fixedDeltaTime); //��ü �̵� (���� ��ġ + ����ȯ�� �̵����� * �ӵ��� * ��ŸŸ��
        rigid.velocity = Vector2.zero; //��ü �ӵ� = 0*/
    }

    private void OnTriggerEnter2D(Collider2D collision) //�浹 �̺�Ʈ ����
=======
    {
        
    }
    void moveCannon()
    {
        Vector3 targetpos = target.position;
        Vector3 rigidpos = rigid.position;
        Vector3 cannon_pos = targetpos + Vector3.right * Random.Range(-7, 7) + Vector3.up * Random.Range(-7, 7);
        Vector3 director = cannon_pos - rigidpos;
        rigid.AddForce(rigidpos + director * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
>>>>>>> 639c65b06df45023916c3820b45abd55947ebe0c:Vampire_Survival_Like/Assets/Script/Enemy/Boss/stage5/Dron_Cannon.cs
    {
        if (collision != null) //�浹�ߴٸ�
        {
            if (collision.gameObject.CompareTag("Player")) //�±װ� �÷��̾��ϋ�
            {
<<<<<<< HEAD:Vampire_Survival_Like/Assets/Script/Enemy/bullet.cs
                Destroy(gameObject); //����
                Debug.Log("�浹!");
=======
                GameManager.instance.Player_damage(15);
                Destroy(gameObject);
>>>>>>> 639c65b06df45023916c3820b45abd55947ebe0c:Vampire_Survival_Like/Assets/Script/Enemy/Boss/stage5/Dron_Cannon.cs
            }
        }
    }
}
