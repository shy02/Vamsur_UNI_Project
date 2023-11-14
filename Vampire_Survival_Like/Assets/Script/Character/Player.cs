using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
<<<<<<< HEAD
=======
    public Scanner scanner;
>>>>>>> main

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
<<<<<<< HEAD
=======
        scanner = GetComponent<Scanner>();
>>>>>>> main
    }

    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
      
        //3.위치이동
        rigid.MovePosition(rigid.position + nextVec);
    }

    private void LateUpdate()
    {
<<<<<<< HEAD
        //anim.SetFloat("Speed" , inputVec.magnitude);
        if(!GameManager.instance.GetComponent<Pause_>().nowPause){   
            if (inputVec.x != 0) {
            spriter.flipX = inputVec.x < 0;
            }
        }
=======
        anim.SetFloat("Speed" , inputVec.magnitude); 
            if (inputVec.x != 0) {
            spriter.flipX = inputVec.x < 0;
            }
>>>>>>> main
    }

    public float GetPlayerSpeed(float speed){      
        speed = this.speed;
        return speed;  
    }
}