using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_vehicle : MonoBehaviour
{
    // Start is called before the first frame update

    SpriteRenderer spriter;

    Rigidbody2D target;
    Rigidbody2D bossPos;

    public GameObject v_bullet;
    public GameObject v_missile;
    public GameObject v_watercannon;

    public float boss_HP=500;
    public float current_boss_HP;
    bool isattack = false;
    float attack_time;
    float dmg_reduce;
    float colltime=5;
    float attack_range = 20;
    double close_range = 3;

    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();
        bossPos = GetComponent<Rigidbody2D>();
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        attack_time += Time.deltaTime;
        colltime += Time.deltaTime;
        dmg_reduce += Time.deltaTime;
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= close_range && colltime >=5) //���� �Ÿ� �̳� ���� �� ������
        {
            Vector2 looking = target.position - bossPos.position;
            float angle = Mathf.Atan2(looking.y, looking.x) * Mathf.Rad2Deg;
            Instantiate(v_watercannon, bossPos.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
            colltime = 0;
        }
        if (attack_time >= 2 && isattack == false)
        {
            if (distance<=attack_range)
            {
                int attack_pattern = Random.Range(1, 4);
                Debug.Log(attack_pattern);
                switch (attack_pattern)
                {
                    case 1: //�Ѿ� ���� �߻�
                        isattack = true;
                        Spawn_v_bullet();
                        Invoke("Spawn_v_bullet", 0.3f);
                        Invoke("Spawn_v_bullet", 0.6f);
                        break;
                    case 2: //���� �̻��� �߻�
                        isattack = true;
                        Vector2 looking = target.position - bossPos.position;
                        float angle = Mathf.Atan2(looking.y, looking.x) * Mathf.Rad2Deg;
                        Instantiate(v_missile, bossPos.position, Quaternion.AngleAxis(angle - 90, Vector3.forward));
                        break;
                    case 3: //EMP �޽� ����
                        Debug.Log("�޽� ����");
                        GameManager.instance.SkillManager.SetActive(false);
                        Invoke("Skill_On", 2f);
                        break;
                }
            }
            attack_time = 0;
            isattack = false;
        }
        if (dmg_reduce >= 30)
        {
            dmg_reduce = 0;
        }
    }

    public void Boss_Damage(float dmg)
    {
        boss_HP = boss_HP - dmg;
        if (dmg_reduce >= 20)
        {
            boss_HP = boss_HP - (dmg / 2);
        }
    }
    void Spawn_v_bullet()
    {
        Instantiate(v_bullet, bossPos.position, Quaternion.identity);
    }
    void Skill_On()
    {
        GameManager.instance.SkillManager.SetActive(true);
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
        spriter.flipX = target.position.x > bossPos.position.x;
    }
}
