using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    public GameObject BananaSp;   // 바나나 스폰 관리자(스크립트) 오브젝트를 참조하는 변수
    public GameObject Data;
    BoxCollider2D box;           // 이 스크립트에서 사용하는 BoxCollider2D를 참조하는 변수
    SpriteRenderer BaRender;    // 이 스크립트에서 사용하는 SpriteRenderer를 참조하는 변수
    public float slowFactor; // 적의 이동 속도를 줄이는 속도 감소 요인을 설정하는 public 변수
    public float Damage;
    private float lv;

    void Start()
    {
        BaRender = GetComponent < SpriteRenderer>();   // 이 스크립트가 연결된 게임 오브젝트의 SpriteRenderer를 참조
        BananaSp = GameObject.Find("Manager").transform.GetChild(1).transform.GetChild(1).gameObject;       // "Banana"라는 이름의 게임 오브젝트를 찾아 BananaSp 변수에 할당
        box = GetComponent < BoxCollider2D>();          // 이 스크립트가 연결된 게임 오브젝트의 BoxCollider2D를 참조
        box.enabled = true;                         // BoxCollider2D를 활성화하여 충돌을 감지할 수 있도록 설정
        
        Data = GameObject.Find("Manager").transform.GetChild(2).gameObject;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            // 충돌한 오브젝트의 태그가 "Enemy" 또는 "Boss"일 경우에 아래의 코드를 실행
            other.GetComponent<Enemy>().Slow(slowFactor);// _Enemy에 Slow() 함수 추가!! 이거 없애고 밑에 주석 지워도 똑같이 느려지지는 않음.

            lv = Data.GetComponent<DataManager>().skill[7].Level;
            Damage = 20f +5.7f*(lv-1);
            Damage = Damage + ((Damage / 100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().Force);
            other.GetComponent<Enemy>().GetDamage(Damage);

            BananaSp.GetComponent<BanaSpawner>().minusNum();
            Destroy(gameObject);
        }
    }
    }




    //public void Erase()                                                //이건 있으나 없으나 똑같이 ?? 작동함
    //{
    //    BananaSp.GetComponent<BanaSpawner>().minusNum();
    //    // BananaSpawner 스크립트의 minusNum 메서드를 호출하여 바나나 수를 감소시킴
    //    Destroy(gameObject);
    //    // 현재 바나나 게임 오브젝트를 파괴하여 화면에서 제거
    //}
