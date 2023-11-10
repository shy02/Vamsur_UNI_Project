
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss5_0_Dron : MonoBehaviour
{
    // Start is called before the first frame update

    SpriteRenderer spriter;

    Rigidbody2D target;
    Rigidbody2D bossPos;

    public GameObject laser;
    public GameObject d_bullet;
    public GameObject cannon;
    public GameObject bounce;
    public Transform[] spawnpoint;

    public float boss_HP = 200;
    public float current_boss_HP;
    bool isattack = false;
    float attack_time;
    float attack_range = 15;
    float speed = 6;

    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();
        bossPos = GetComponent<Rigidbody2D>();
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (current_boss_HP < 0.01f)
        {
            Destroy(gameObject);
        }
        attack_time += Time.deltaTime;
        float distance = Vector3.Distance(transform.position, target.position);

        Vector2 director = target.position - bossPos.position;
        Vector2 next = director.normalized * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, target.position) > 8)
        {
            bossPos.MovePosition(bossPos.position + next);
        }
        if (attack_time >= 3 && isattack == false)
        {
            if (distance <= attack_range)
            {
                int attack_pattern = Random.Range(1, 5);
                Debug.Log(attack_pattern);
                switch (attack_pattern)
                {
                    case 1: //대량 총탄 공격
                        isattack = true;
                        bullet_attack();
                        Invoke("bullet_attack",0.2f);
                        Invoke("bullet_attack", 0.4f);
                        Invoke("bullet_attack", 0.6f);
                        Invoke("bullet_attack", 0.8f);
                        break;
                    case 2: //4갈래 방향 레이저 발사(방향 바꾸고 2번)
                        isattack = true;
                        Instantiate(laser, bossPos.position, Quaternion.AngleAxis(0, Vector3.forward));
                        Instantiate(laser, bossPos.position, Quaternion.AngleAxis(90, Vector3.forward));
                        Invoke("laser_attack", 1f);
                        break;
                    case 3: //벽 튕기는 투사체 발사
                        isattack = true;
                        Instantiate(bounce, bossPos.position, Quaternion.identity);
                        break;
                    case 4: //랜덤한 위치로 포탄 발사
                        isattack = true;
                        Instantiate(cannon, bossPos.position, Quaternion.identity);
                        break;
                }
                
            }
            attack_time = 0;
            isattack = false;
        }
    }

    public void Boss_Damage(float dmg)
    {
        boss_HP = boss_HP - dmg;
    }
    void laser_attack()
    {
        Instantiate(laser, bossPos.position, Quaternion.AngleAxis(45, Vector3.forward));
        Instantiate(laser, bossPos.position, Quaternion.AngleAxis(135, Vector3.forward));
    }
    void bullet_attack()
    {
        Instantiate(d_bullet,spawnpoint[0].position, Quaternion.identity);
        Instantiate(d_bullet, spawnpoint[1].position, Quaternion.identity);
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.gameObject.CompareTag("Player"))
        {
            GameManager.instance.Player_damage(0.5f);
        }
    }
    private void LateUpdate()
    {
        spriter.flipX = target.position.x < bossPos.position.x;
    }
}
