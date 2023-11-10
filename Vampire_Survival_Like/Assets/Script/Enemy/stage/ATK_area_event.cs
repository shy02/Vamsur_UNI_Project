using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATK_area_event : MonoBehaviour
{
   BoxCollider2D area; // ���� ���� ����
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

        //������ �Լ� �ʿ�
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
