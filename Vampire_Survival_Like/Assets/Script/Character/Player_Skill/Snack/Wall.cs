using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    Rigidbody2D rigid;

    void Start(){
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rigid.velocity = Vector2.zero;

    }
}
