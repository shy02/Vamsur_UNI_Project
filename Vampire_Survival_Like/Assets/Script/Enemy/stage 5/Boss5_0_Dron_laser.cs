using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss5_0_Dron_laser : MonoBehaviour
{
    // Start is called before the first frame update

    void OnEnable()
    {
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                GameManager.instance.Player_damage(1);
            }
        }
    }
}
