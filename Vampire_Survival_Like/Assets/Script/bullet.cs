using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float speed= 0.1f; // �ӵ��� ����
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 director = target.position - rigid.position; //��ü �̵����� ����
        rigid.MovePosition(rigid.position + director.normalized * speed * Time.fixedDeltaTime); //��ü �̵� (���� ��ġ + ����ȯ�� �̵����� * �ӵ��� * ��ŸŸ��
        rigid.velocity = Vector2.zero; //��ü �ӵ� = 0
    }

    private void OnTriggerEnter2D(Collider2D collision) //�浹 �̺�Ʈ ����
    {
        if (collision != null) //�浹�ߴٸ�
        {
            if (collision.gameObject.CompareTag("Player")) //�±װ� �÷��̾��ϋ�
            {
                Destroy(gameObject); //����
                Debug.Log("�浹!");
            }
        }
    }


}
