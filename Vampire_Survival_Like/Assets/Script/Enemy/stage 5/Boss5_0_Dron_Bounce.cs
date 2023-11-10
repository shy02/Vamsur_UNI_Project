using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss5_0_Dron_Bounce : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 200000f;
    Rigidbody2D bounce, target;
    void Start()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        bounce = GetComponent<Rigidbody2D>();
        Vector2 director = target.position - bounce.position;
        bounce.AddForce(bounce.position + director.normalized * speed * Time.deltaTime);
        bounce.velocity = Vector2.zero;

        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.Player_damage(5);
        }
    }
}
