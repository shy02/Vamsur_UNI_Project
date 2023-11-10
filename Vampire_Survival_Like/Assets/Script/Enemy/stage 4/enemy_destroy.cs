using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_destroy : MonoBehaviour
{
    public GameObject Drop_exp;
    SpriteRenderer sprite;
    Rigidbody2D rigid, target;
    new Collider2D collider;

    float time;
    public float speed = 4;
    bool isdamaged;
    public float damage;
    bool isattack;
    int num = 6;
    float green, blue;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<CapsuleCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        collider.enabled = false;
        isattack = false;
        green = 255f;
        blue = 255f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (isattack == true)
        {
            if (time > 0.5f)
            {
                time = 0;
                num -= 1;
                green -= 45f;
                blue -= 45f;
                Debug.Log(sprite.color);
                update_color();
            }
            if (num == 1)
            {
                attack();
            }

        }
        else if (isattack == false)
        {
            Vector2 director = target.position - rigid.position;
            Vector2 next = director.normalized * speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + next);
            if (Vector3.Distance(transform.position, target.position) < 0.3f)
            {
                isattack = true;
                time = 0;
            }
        }
    }
    public void attack()
    {
        collider.enabled = true;
        Destroy(gameObject, 0.2f);
    }

    private void Drop_Exp()
    {
        Vector3 spawnPosition = transform.position;
        Debug.Log(spawnPosition);
        Instantiate(Drop_exp, spawnPosition, Quaternion.identity);
    }
    private void update_color()
    {
        sprite.color = new Color(255f / 255f, green / 255f, blue / 255f, 255f / 255f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player") && collider.enabled && !isdamaged)
            {
                GameManager.instance.Player_damage(damage);
                isdamaged = true;
            }
        }
    }
}
