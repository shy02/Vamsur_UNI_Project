using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour
{
    

    [SerializeField] [Range(500f, 2000f)] float speed = 1000f;    // 간식 이동속도 500f~2000f로 설정
    public Rigidbody2D rb;
    float randomX, randomY;

    void start()
    {
       
        rb = GetComponent<Rigidbody2D>();

        randomX = Random.Range(-1f, 1f);                 //랜덤값
        randomY = Random.Range(-1f, 1f);

        Vector2 dir = new Vector2(randomX, randomY).normalized;

        rb.AddForce(dir * speed);                               // 방향*스피드로 힘을 가함


        update();
        

        
    }

    
    void update()
    {
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        if (position.x < 0f)
        {
            position.x = 0f;
            randomX = Random.Range(0.3f, 1.0f);
        }
        if (position.y < 0f)
        {
            position.y = 0f;
            randomY = Random.Range(0.3f, 1.0f);
        }
        if (position.x > 1f)
        {
            position.x = 1f;
            randomX = Random.Range(-1.0f, -0.3f);
        }
        if (position.y > 1f)
        {
            position.y = 1f;
            randomY = Random.Range(-1.0f, -0.3f);
        }
    }
    
}