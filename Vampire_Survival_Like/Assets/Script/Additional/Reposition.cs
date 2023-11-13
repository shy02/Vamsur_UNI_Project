using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class Reposition : MonoBehaviour

{
    void start(){
        Debug.Log("아임히어");
    }
    int tilecount = 74;
    void OnTriggerExit2D(Collider2D collision)

    {

        if (!collision.CompareTag("Area"))

            return;



        Vector3 playerPos = GameManager.instance.player.transform.position;

        Vector3 myPos = transform.position;

        float diffX = Mathf.Abs(playerPos.x - myPos.x);

        float diffY = Mathf.Abs(playerPos.y - myPos.y);



        Vector3 playerDir = GameManager.instance.player.inputVec;

        float dirX = playerDir.x < 0 ? -1 : 1;

        float dirY = playerDir.y < 0 ? -1 : 1;



       switch (transform.tag) {

            case "Ground":

                if (Mathf.Abs(diffX - diffY) <= 0.1f) {

                    transform.Translate(Vector3.up * dirY * tilecount);

                    transform.Translate(Vector3.right * dirX * tilecount);

                }

                else if (diffX > diffY) {

                    transform.Translate(Vector3.right * dirX * tilecount);

                }

                else if (diffX < diffY) {

                    transform.Translate(Vector3.up * dirY * tilecount);

                }

                break;

            case "Enemy":
            
                break;

        
        }

    }

}
