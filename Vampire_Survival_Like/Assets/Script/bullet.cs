using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float speed= 0.1f; // 속도값 설정
    Rigidbody2D rigid, target;

    Transform playerPos;

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>(); //플레이어의 물리값 가져오기
    }

    // Start is called before the first frame update
    void Start()
    {    
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 director = target.position - rigid.position; //물체 이동방향 설정
        rigid.MovePosition(rigid.position + director.normalized * speed * Time.fixedDeltaTime); //물체 이동 (현재 위치 + 정규환된 이동방향 * 속도값 * 델타타임
        rigid.velocity = Vector2.zero; //물체 속도 = 0
    }

    private void OnTriggerEnter2D(Collider2D collision) //충돌 이벤트 설정
    {
        if (collision != null) //충돌했다면
        {
            if (collision.gameObject.CompareTag("Player")) //태그가 플레이어일떄
            {
                Destroy(gameObject); //삭제
                Debug.Log("충돌!");
            }
        }
    }


}
