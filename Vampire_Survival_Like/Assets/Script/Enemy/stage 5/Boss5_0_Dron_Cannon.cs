using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss5_0_Dron_Cannon : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D target,rigid;

    float speed = 20000f;

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        rigid = GetComponent<Rigidbody2D>();
        moveCannon();
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    void moveCannon()
    {
        Vector3 targetpos = target.position;
        Vector3 rigidpos = rigid.position;
        Vector3 cannon_pos = targetpos + Vector3.right * Random.Range(-7, 7) + Vector3.up * Random.Range(-7, 7);
        Vector3 director = cannon_pos - rigidpos;
        rigid.AddForce(rigidpos + director * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.instance.Player_damage(15);
                Destroy(gameObject);
            }
        }
    }
}
