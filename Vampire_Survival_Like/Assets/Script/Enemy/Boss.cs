using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Animator animator;
    float timer;

    Rigidbody2D target;
    Rigidbody2D bossPos;
    public Transform[] L_Point;

    public GameObject s_bullet;
    public GameObject Enemy_L;

    public int boss_HP;
    public int current_boss_HP;
    public float spawn_police_time;
    float attack_time;
    bool isattack=false;
    float attack_range=7;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isfirst", false);

        L_Point = GetComponentsInChildren<Transform>();

        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        bossPos = GetComponent<Rigidbody2D>();
        boss_HP = 200;
        current_boss_HP = boss_HP;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        spawn_police_time += Time.deltaTime;
        attack_time += Time.deltaTime;
        if(timer > 1)
        {
            animator.SetBool("isfirst", false);
        }

        float distance = Vector3.Distance(transform.position, target.position);
        
        if (attack_time >= 3&&isattack==false)
        {
            Debug.Log(distance);
            if (distance <= attack_range)
            {
                isattack = true;
                //근접공격
                Debug.Log("melle attack");

            }
            else if (distance > attack_range)
            {
                //스턴건 공격
                isattack = true;
                Instantiate(s_bullet,bossPos.position, Quaternion.identity);
                Debug.Log("stungun attack");
            }

            if (spawn_police_time >= 20)
            {
                //경관 소환
                isattack = true;
                Instantiate(Enemy_L, L_Point[1].position, Quaternion.identity);
                Instantiate(Enemy_L, L_Point[2].position, Quaternion.identity);
                spawn_police_time = 0;
            }
            attack_time = 0;
            isattack = false;
        }


    }
}
