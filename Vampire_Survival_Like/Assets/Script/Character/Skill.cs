using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public float damage;
    public int per;

    public void Init(float damage, int per)
    {
        this.damage = damage;
        this.per = per;
    }


    /*
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            // 충돌한 오브젝트의 태그가 "Enemy" 또는 "Boss"일 경우에 아래의 코드를 실행
            other.GetComponent<_Enemy>().Dead();
    }

    }

    */
}
