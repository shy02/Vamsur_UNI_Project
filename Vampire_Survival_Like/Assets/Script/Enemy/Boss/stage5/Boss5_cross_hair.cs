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
    public bool isdamaged;
    public float damage;
    bool isSound;

    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<CircleCollider2D>();
        rigid = GetComponent<Rigidbody2D>();

        sprite.sprite = img[0];
        is_attack = false;
        isdamaged = false;
        collider.enabled = false;
        isSound = false;
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

            if (time > 2)
            {
                //공격할때 이미지 변경
                sprite.sprite = img[2];
                if(!isSound)
                {
                    isSound = true;
                    AudioManager.A_instance.PlaySfx(AudioManager.Sfx.pattern7);
                }
                //공격
                collider.enabled = true;
                if (time > 3)
                {
                    recet();
                    time = 0;
                }
            }

        }
    }
    public void recet()
    {
        sprite.sprite = img[0];
        is_attack = false;
        isdamaged = false;
        isSound = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            //Debug.Log(collision.gameObject.CompareTag("Player") && !isdamaged);
            if (collision.gameObject.CompareTag("Player") && !isdamaged)
            {
                GameManager.instance.Player_damage(damage);
                isdamaged = true;
                //Debug.Log("Wtf_OnTriggerEN");
                collider.enabled = false;

            }
        }
    }

}
