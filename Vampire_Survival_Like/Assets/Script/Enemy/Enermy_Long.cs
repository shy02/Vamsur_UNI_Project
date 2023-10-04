using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy_Long : MonoBehaviour
{
    public float distance;
    public LayerMask isLayer;
    public float speed;
    public float atkDistance;
    public GameObject Bullet;
    public Transform pos;
    Rigidbody2D rigid;
    public Rigidbody2D target;


    // Start is called before the first frame update
    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }
    public float cooltime;
    public float currenttime;
    SpriteRenderer spriter;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 director = target.position - rigid.position;
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, transform.right * -1f, distance, isLayer);

        if (raycast.collider != null)
        {
            if(Vector2.Distance(transform.position, raycast.collider.transform.position) < atkDistance)
            {
                if(currenttime <= 0)
                {
                    GameObject Bulletcopy = Instantiate(Bullet, pos.position, transform.rotation);
                    currenttime = cooltime;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, raycast.collider.transform.position, Time.deltaTime * speed);
            }
            currenttime -= Time.deltaTime;
        }
    }
    void LateUpdate()
    {
        spriter.flipX = target.position.x > rigid.position.x;
    }
}
