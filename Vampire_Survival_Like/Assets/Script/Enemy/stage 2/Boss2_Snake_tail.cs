using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Snake_tail : MonoBehaviour
{
    public float blind_time = 1; // 공격 시도 시간
    public float del_time = 5; // 삭제 시간
    public float time;
    SpriteRenderer tail;
    Collider2D area;
    // Start is called before the first frame update
    void Start()
    {
        //꼬리 이미지 끄기
        tail = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        tail.enabled = false;

        area = gameObject.GetComponent<Collider2D>();
        area.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //일정 시간 후 공격
        time += Time.deltaTime;
        if (time> blind_time)
        {
            area.enabled = true;
            tail.enabled = true;
        }

        // 일정 시간후 삭제
        if(time>del_time)
        {
            Destroy(gameObject);
        }
    }

    //꼬리가 생기고, 콜라이더에 Player 태그가 있고, 콜라이더가 켜저 있을 때 플레이어 데미지
    public void OnTriggerStay2D(Collider2D other)
    {    
        if (other.CompareTag("Player"))
            GameManager.instance.GetComponent<GameManager>().Player_damage(10);
    }
}
