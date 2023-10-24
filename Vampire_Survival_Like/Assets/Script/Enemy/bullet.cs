using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask isLayer;
    Rigidbody2D rigid, target;

    float time = 0;

    Transform playerPos;

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f;
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 director = target.position - rigid.position;

        rigid.MovePosition(rigid.position + director.normalized * speed);

        rigid.velocity = Vector2.zero;

        //time += Time.deltaTime;
        //if (time > 5.0f)
        //{
        //}

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
                Debug.Log("Ãæµ¹!");
            }
        }
    }


}
