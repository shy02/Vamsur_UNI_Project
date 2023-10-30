using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATK_area_event : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(transform.name);
        //데미지 함수 필요
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
