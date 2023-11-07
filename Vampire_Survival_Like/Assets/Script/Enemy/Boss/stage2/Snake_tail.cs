using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_tail : MonoBehaviour
{
    public float blind_time = 1; // ���� �õ� �ð�
    public float del_time = 5; // ���� �ð�
    public float time;
    SpriteRenderer tail;
    Collider2D area;
    // Start is called before the first frame update
    void Start()
    {
        //���� �̹��� ����
        tail = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        tail.enabled = false;

        area = gameObject.GetComponent<Collider2D>();
        area.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //���� �ð� �� ����
        time += Time.deltaTime;
        if (time> blind_time)
        {
            area.enabled = true;
            tail.enabled = true;
        }

        // ���� �ð��� ����
        if(time>del_time)
        {
            Destroy(gameObject);
        }
    }

    //������ �����, �ݶ��̴��� Player �±װ� �ְ�, �ݶ��̴��� ���� ���� �� �÷��̾� ������
    public void OnTriggerStay2D(Collider2D other)
    {    
        if (other.CompareTag("Player"))
            GameManager.instance.GetComponent<GameManager>().Player_damage(0.5f);
    }
}
