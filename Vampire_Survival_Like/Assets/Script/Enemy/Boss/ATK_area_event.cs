using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATK_area_event : MonoBehaviour
{
<<<<<<< HEAD
    // Start is called before the first frame update
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(transform.name);
        //µ¥¹ÌÁö ÇÔ¼ö ÇÊ¿ä
=======
   BoxCollider2D area; // ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½
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

>>>>>>> main
    }
}
