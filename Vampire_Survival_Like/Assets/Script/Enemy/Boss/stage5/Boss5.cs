using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss5 : MonoBehaviour
{
    Rigidbody2D target, rigid;
    SpriteRenderer spriter;
    public GameObject bullet, bomb,sniper;
    public float cool;
    float recovery_time;
    public float boss_HP, current_boss_HP;


    // Start is called before the first frame update
    void Start()
    {
        current_boss_HP = boss_HP;
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (current_boss_HP < 0.01f)
        {
            GameManager.instance.bossisdead = true;
            GameManager.instance.GetComponent<GameManager>().Survied();
            Destroy(gameObject);
        }
        cool += Time.deltaTime;
        
        if (cool > 2)
        {
            cool = 0;
            int random_ = Random.Range(1, 3);
            int rnd_num = Random.Range(2, 6);
            switch (random_)
            {
                case 1:
                    for (int i = 1; i < rnd_num; i++)
                    {
                        Invoke("spawn_bullet", 0.1f*i);
                    }
                    break;
                case 2:
                    AudioManager.A_instance.PlaySfx(AudioManager.Sfx.pattern6);
                    Instantiate(bomb, rigid.position, Quaternion.identity);
                    break;
            }
        }
        if (current_boss_HP <= boss_HP / 2) //보스 체력 반 이하일때 실행
        {
            recovery_time += Time.deltaTime;
            if (recovery_time >= 20) //20초마다 피 20씩 회복
            {
                current_boss_HP += 20;
                Vector3 s_target = target.position;
                Vector3 sniper_pos = s_target + Vector3.right * Random.Range(-2, 2) + Vector3.up * Random.Range(-2, 2);
                Instantiate(sniper, sniper_pos, Quaternion.identity);
                recovery_time = 0;
            }
        }

    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.gameObject.CompareTag("Player"))
        {
            GameManager.instance.Player_damage(0.5f);
        }
    }

    public void GetDamage(float dmg)
    {
        AudioManager.A_instance.PlaySfx(AudioManager.Sfx.e_hit);
        current_boss_HP = current_boss_HP - dmg;
    }
    void spawn_bullet()
    {
        AudioManager.A_instance.PlaySfx(AudioManager.Sfx.pattern3);
        Instantiate(bullet, rigid.position, Quaternion.identity);
    }
    private void LateUpdate()
    {
        spriter.flipX = target.position.x < rigid.position.x;
    }
}
