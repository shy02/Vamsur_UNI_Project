using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dron_Cannon : MonoBehaviour
{
<<<<<<< HEAD:Vampire_Survival_Like/Assets/Script/Enemy/bullet.cs
    private float speed= 5000f; // 속도값 설정
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
        Vector2 director = target.position - rigid.position; //물체 이동방향 설정
        rigid.AddForce(rigid.position + director.normalized * speed * Time.fixedDeltaTime); //물체 이동 (현재 위치 + 정규환된 이동방향 * 속도값 * 델타타임
        rigid.velocity = Vector2.zero; //물체 속도 = 0
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
        Vector2 director = target.position - rigid.position; //물체 이동방향 설정
        rigid.MovePosition(rigid.position + director.normalized * speed * Time.fixedDeltaTime); //물체 이동 (현재 위치 + 정규환된 이동방향 * 속도값 * 델타타임
        rigid.velocity = Vector2.zero; //물체 속도 = 0*/
    }

    private void OnTriggerEnter2D(Collider2D collision) //충돌 이벤트 설정
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
        if (collision != null) //충돌했다면
        {
            if (collision.gameObject.CompareTag("Player")) //태그가 플레이어일떄
            {
<<<<<<< HEAD:Vampire_Survival_Like/Assets/Script/Enemy/bullet.cs
                Destroy(gameObject); //삭제
                Debug.Log("충돌!");
=======
                GameManager.instance.Player_damage(15);
                Destroy(gameObject);
>>>>>>> 639c65b06df45023916c3820b45abd55947ebe0c:Vampire_Survival_Like/Assets/Script/Enemy/Boss/stage5/Dron_Cannon.cs
            }
        }
    }
}
