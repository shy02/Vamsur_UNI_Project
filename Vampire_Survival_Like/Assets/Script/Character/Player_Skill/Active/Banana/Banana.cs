using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    public GameObject BananaSp;   // 바나나 스폰 관리자(스크립트) 오브젝트를 참조하는 변수
    BoxCollider2D box;           // 이 스크립트에서 사용하는 BoxCollider2D를 참조하는 변수
    SpriteRenderer BaRender;    // 이 스크립트에서 사용하는 SpriteRenderer를 참조하는 변수
    public float slowFactor = 0.02f; // 적의 이동 속도를 줄이는 속도 감소 요인을 설정하는 public 변수
    public float Damage;
    private float lv;
    public bool isFinal;
    public int stage = 1;
    private DataManager data;

    void Start()
    {
        BaRender = GetComponent < SpriteRenderer>();   // 이 스크립트가 연결된 게임 오브젝트의 SpriteRenderer를 참조
        BananaSp = GameObject.Find("BananaSpawner");       // "Banana"라는 이름의 게임 오브젝트를 찾아 BananaSp 변수에 할당
        box = GetComponent <BoxCollider2D>();          // 이 스크립트가 연결된 게임 오브젝트의 BoxCollider2D를 참조
        box.enabled = true;                         // BoxCollider2D를 활성화하여 충돌을 감지할 수 있도록 설정
        data = GameManager.instance.DataManager.GetComponent<DataManager>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        AudioManager.A_instance.PlaySfx(AudioManager.Sfx.banana);
        if (other.CompareTag("Enemy"))
        {
            if (!isFinal)
            {
                NormalDamage();
            }
            else
            {
                finalDamage();
            }
            other.GetComponent<Enemy>().Slow(slowFactor);
            other.GetComponent<Collider2D>().gameObject.GetComponent<Enemy>().GetDamage(Damage);
            BananaSp.GetComponent<BanaSpawner>().minusNum();
            Destroy(gameObject);
        }
        if (other.CompareTag("Boss"))
        {
            if (!isFinal)
            {
                NormalDamage();
            }
            else
            {
                finalDamage();
            }
            switch (stage)
            {
                case 1:
                    other.GetComponent<Collider2D>().gameObject.GetComponent<Boss1>().GetDamage(Damage);
                    break;

                case 2:
                    other.GetComponent<Collider2D>().gameObject.GetComponent<Boss2>().GetDamage(Damage);
                    break;

                case 3:
                    other.GetComponent<Collider2D>().gameObject.GetComponent<Boss3>().GetDamage(Damage);
                    break;

                case 4:
                    other.GetComponent<Collider2D>().gameObject.GetComponent<Boss4>().GetDamage(Damage);
                    break;

                case 5:
                    other.GetComponent<Collider2D>().gameObject.GetComponent<Boss50>().GetDamage(Damage);
                    break;
                case 6:
                    other.GetComponent<Collider2D>().gameObject.GetComponent<Boss5>().GetDamage(Damage);
                    break;
                default:
                    break;

            BananaSp.GetComponent<BanaSpawner>().minusNum();
            Destroy(gameObject);
            }
        }
        }

        public void NormalDamage(){
            lv = data.skill[7].Level;
            Damage = 20f+5.7f*(lv-1);
        }
        public void finalDamage(){
            
        }
    }