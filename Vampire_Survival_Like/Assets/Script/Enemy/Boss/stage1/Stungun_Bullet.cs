using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stungun_Bullet : MonoBehaviour
{
    // Start is called before the first frame update

<<<<<<< HEAD
    private float speed = 500000f;
=======
    private float speed = 20000f;
    private float p_speed;
    public Animator anime;
>>>>>>> main
    Rigidbody2D s_bullet, target;

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        s_bullet = GetComponent<Rigidbody2D>();
        Vector2 director = target.position - s_bullet.position;
        s_bullet.AddForce(s_bullet.position+director.normalized *speed* Time.deltaTime);
        s_bullet.velocity = Vector2.zero;
<<<<<<< HEAD

        Destroy(gameObject, 5f);
=======
        anime = GameObject.Find("Effect").GetComponent<Animator>();

        Destroy(gameObject, 3f);
>>>>>>> main
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
<<<<<<< HEAD
                Destroy(gameObject);
            }
        }
    }
=======
                anime.SetBool("isStun", true);
                GameManager.instance.Player_damage(15);
                p_speed = GameManager.instance.player.speed;
                GameManager.instance.player.speed = 0;
                Invoke("Player_Speed_Return", 1.5f);
                gameObject.SetActive(false);
            }
        }
    }
    void Player_Speed_Return()
    {
        GameManager.instance.player.speed = p_speed;
        anime.SetBool("isStun", false);
        Destroy(gameObject);
    }
>>>>>>> main
}
