using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle_Missile : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 100000f;
    Rigidbody2D v_missile, target;
    Vector3 lookDir;

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        v_missile = GetComponent<Rigidbody2D>(); 
        Vector2 director = target.position - v_missile.position;
        v_missile.AddForce(v_missile.position + director.normalized * speed * Time.deltaTime);
        v_missile.velocity = Vector2.zero;
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
                GameManager.instance.Player_damage(10);
                Destroy(gameObject);
            }
        }
    }
}

