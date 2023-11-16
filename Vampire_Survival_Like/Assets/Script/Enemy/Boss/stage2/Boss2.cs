using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{

    Rigidbody2D target;
    Rigidbody2D rigid;
    SpriteRenderer spriter;

    public GameObject tail;
    public GameObject fog;

    public float boss_HP; //보스 초기 체력
    public float current_boss_HP; // 보스 현재 체력
    float timer;
    float fog_time;
    float attack_time; //공격 딜레이 타이머
    public float cooltime = 3; //공격 딜레이

    bool isattack = false; //공격 유무
    bool fog_area = false;

    int random_;
    float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        rigid = GetComponent<Rigidbody2D>();
        boss_HP = 200;
        current_boss_HP = boss_HP;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (current_boss_HP <= 0.01f)
        {
            GameManager.instance.GetComponent<GameManager>().Survied();
            Destroy(gameObject);
        }
        //시간 계산
        timer += Time.deltaTime;
        attack_time += Time.deltaTime;

        //보스 방향
        Vector2 director = target.position - rigid.position;
        Vector2 next = director.normalized * speed * Time.deltaTime;

        //보스 이동 + 거리 제한
        speed = Vector3.Distance(transform.position, target.position) / 2f;
        rigid.MovePosition(rigid.position + next);

        //공격 변수
        random_ = Random.Range(1, 4);

        //꼬리 위치
        Vector3 targer_3 = target.position;
        Vector3 tail_pos = targer_3 + Vector3.right * Random.Range(-3, 3) + Vector3.up * Random.Range(-3, 3);

       
        //공격
        if (attack_time >= cooltime && isattack == false && fog_area == false)
        {
            switch (random_)
            {
                case 1:
                    //꼬리 공격 1개
                    isattack = true;
                    Instantiate(tail, tail_pos, Quaternion.identity);
                    Debug.Log("TaiL");
                    attack_time = 0;
                    break;
                case 2:
                    //꼬리 공격 2개
                    isattack = true;
                    Vector3 tail_pos2 = tail_pos + Vector3.right* Random.Range(-3, 3) + Vector3.up * Random.Range(-3, 3);
                    Instantiate(tail, tail_pos, Quaternion.identity);
                    Instantiate(tail, tail_pos2, Quaternion.identity);
                    Debug.Log("TaiL2");
                    attack_time = 0;
                    break;
                case 3:
                    //독안개
                    isattack = true;
                    fog_attack(3);
                    Debug.Log("FoG");
                    attack_time = 0;
                    AudioManager.A_instance.PlaySfx(AudioManager.Sfx.pattern1);
                    break;
            }
            isattack = false;
        }
    }
    void fog_attack(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Vector3 bossrigid = rigid.position;
            Vector3 fog_pos = bossrigid + Vector3.right * Random.Range(-7, 7) + Vector3.up * Random.Range(-7, 7);
            Instantiate(fog, fog_pos, Quaternion.identity);
        }
    }
    public void GetDamage(float dmg)
    {
        current_boss_HP = current_boss_HP - dmg;
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
        spriter.flipX = target.position.x < rigid.position.x;
    }
}
