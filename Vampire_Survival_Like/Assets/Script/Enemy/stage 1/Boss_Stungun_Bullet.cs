using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Stungun_Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    private float speed = 300000f;
    private float p_speed;
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

        Destroy(gameObject, 5f);
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
                GameManager.instance.Player_damage(5);
                p_speed = GameManager.instance.player.speed;
                Debug.Log(p_speed);
                GameManager.instance.player.speed = 0;
                Invoke("Player_Speed_Return", 3f);
                gameObject.SetActive(false);
            }
        }
    }
    
    void Player_Speed_Return()
    {
        GameManager.instance.player.speed = p_speed;
        Destroy(gameObject);
    }
}
