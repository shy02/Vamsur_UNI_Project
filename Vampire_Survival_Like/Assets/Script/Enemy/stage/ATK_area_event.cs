using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATK_area_event : MonoBehaviour
{
   BoxCollider2D area; // 근접 공격 범위
    void Start()
    {
        area = GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        disable();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
       disable();

        //데미지 함수 필요
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("OnTriggerStay2D");
        //disable();
    }

    void disable()
    {
        area.enabled = false;
        Debug.Log("area.enabled = false");

    }



}
