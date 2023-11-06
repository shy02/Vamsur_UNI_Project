using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 300000f;
    Rigidbody2D v_bullet, target;

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        v_bullet = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        v_bullet = GetComponent<Rigidbody2D>();
        Vector2 director = target.position - v_bullet.position;
        v_bullet.AddForce(v_bullet.position + director.normalized * speed * Time.deltaTime);
        v_bullet.velocity = Vector2.zero;

        Destroy(gameObject, 3f);
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
                Destroy(gameObject);
            }
        }
    }
}
