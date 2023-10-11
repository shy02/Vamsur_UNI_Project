using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{

    Collider2D coll;

    void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerDir = GameManager.instance.player.inputVec;

        switch (transform.tag)
        {
            case "Enemy":
                if (coll.enabled)
                {
                    transform.Translate(playerDir*20+new Vector3(Random.Range(-3f,3f),Random.Range(-3f,3f),0));
                }//플레이어 근처로 이동
                break;
        }
    }
}
