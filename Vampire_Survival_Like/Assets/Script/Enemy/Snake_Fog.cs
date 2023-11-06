using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Fog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        //Fog_Area 콜라이더에 Player 태그가 있고, 콜라이더가 켜저 있을 때 플레이어 데미지
        if (other.CompareTag("Player"))
        {
            GameManager.instance.Player_damage(1);
        }
    }
}
