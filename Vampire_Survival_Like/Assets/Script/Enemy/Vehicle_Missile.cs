using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle_Missile : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 4f;
    Rigidbody2D v_missile, target;

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        v_missile = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 director = target.position - v_missile.position;
        Vector2 looking = target.position - v_missile.position;
        float angle = Mathf.Atan2(looking.y, looking.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        v_missile.MovePosition(v_missile.position + director.normalized * speed * Time.deltaTime);
        v_missile.velocity = Vector2.zero;
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

