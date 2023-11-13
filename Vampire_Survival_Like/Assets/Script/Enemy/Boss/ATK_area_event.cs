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
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("OnTriggerStay2D");
        if (collision.GetComponent<Collider2D>().gameObject.CompareTag("Player"))
        {
            GameManager.instance.Player_damage(15f);
        }
        disable();
    }

    void disable()
    {
        area.enabled = false;
        Debug.Log("area.enabled = false");

    }
}
