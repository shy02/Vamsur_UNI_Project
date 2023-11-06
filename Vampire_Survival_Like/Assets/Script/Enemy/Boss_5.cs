using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_5 : MonoBehaviour
{
    Rigidbody2D target, rigid;
    SpriteRenderer spriter;
    public GameObject bullet, bomb;
    public float time, cool;
    // Start is called before the first frame update
    void Start()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cool += Time.deltaTime;
        if (cool > 2)
        {
            cool = 0;
            int random_ = Random.Range(1, 2);
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
                    time += Time.deltaTime;
                    if (time > 1)
                    {
                        Instantiate(bomb, rigid.position, Quaternion.identity);
                        time = 0;
                    }
                    break;
            }
        }


    }

    void spawn_bullet()
    {
        Instantiate(bullet, rigid.position, Quaternion.identity);

    }
}
