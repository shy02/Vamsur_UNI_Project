using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss5_cross_hair : MonoBehaviour
{
    public Sprite[] img;
    SpriteRenderer sprite;
    Rigidbody2D rigid, target;
    new Collider2D collider;

    float time;
    public float speed = 4;
    bool is_attack;
    bool isdamaged;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<CircleCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        sprite.sprite = img[0];
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        is_attack = false;
        isdamaged = false;
        collider.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (is_attack == false)
        {
            //이동
            Vector2 director = target.position - rigid.position;
            Vector2 next = director.normalized * speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + next);
            //공격 준비
            if (Vector3.Distance(transform.position, target.position) < 0.3f)
            {
                is_attack = true;
            }
        }
        else if (is_attack == true)
        {
            //색이 바뀜
            time += Time.deltaTime;
            sprite.sprite = img[1];

            if (time >= 1)
            {
                //공격할때 이미지 변경
                //sprite.sprite = img[2];
                //공격
                collider.enabled = true;
                Destroy(gameObject,0.1f);
            }
            /*if (time > 2)
            {
                //공격후 복구
                sprite.sprite = img[0];
                is_attack = false;
                collider.enabled = true;
                time = 0;
            }*/
        }

    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player")&&collider.enabled&&!isdamaged)
            {
                GameManager.instance.Player_damage(25);
                isdamaged = true;
            }
        }
    }
}
