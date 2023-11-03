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

    public int boss_HP=500;
    public int current_boss_HP;
    bool isattack = false;
    float attack_time;
    float attack_range = 20;
    double close_range = 2.5;

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
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= close_range)
        {
            //¹Ð°Ý
        }
        if (attack_time >= 2 && isattack == false)
        {
            if (distance<=attack_range)
            {
                int attack_pattern = Random.Range(1, 3);
                Debug.Log(attack_pattern);
                switch (attack_pattern)
                {
                    case 1:
                        isattack = true;
                        Spawn_v_bullet();
                        Invoke("Spawn_v_bullet", 0.3f);
                        Invoke("Spawn_v_bullet", 0.6f);
                        break;
                    case 2: //Æ÷Åº
                        isattack = true;
                        Instantiate(v_missile, bossPos.position, Quaternion.identity);
                        break;
                    case 3: //EMP ÆÞ½º ¹æÃâ?
                        Debug.Log("ÆÞ½º ¹æÃâ");
                        break;
                }
            }
            attack_time = 0;
            isattack = false;
        }
    }
    void Spawn_v_bullet()
    {
        Instantiate(v_bullet, bossPos.position, Quaternion.identity);
    }
    private void LateUpdate()
    {
        spriter.flipX = target.position.x > bossPos.position.x;
    }
}
