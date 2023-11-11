using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    [SerializeField] float healAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager c = other.gameObject.GetComponent<GameManager>();
        
        /* if(c != null) 테스트
        {
            
        } */

        c.Heal(healAmount);

        if (other.CompareTag("Player")){

        }

    }


}
