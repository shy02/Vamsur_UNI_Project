

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public float damage;
    public int per;


    public void Init(float damage, int per)
    {
        this.damage = damage;
        this.per = per;


    }

    //public void Update()
    //{
    //    angle += speed * Time.deltaTime;
    //    transform.position = center.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
    //}




    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            // 충돌한 오브젝트의 태그가 "Enemy" 또는 "Boss"일 경우에 아래의 코드를 실행
            other.GetComponent<_Enemy>().Dead();                                                // _Enemy에 Slow() 함수 추가!! 이거 없애고 밑에 주석 지워도 똑같이 느려지지는 않음.


        }
    }
}