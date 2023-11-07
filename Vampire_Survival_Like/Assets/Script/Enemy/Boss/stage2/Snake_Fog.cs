using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Fog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        //Fog_Area �ݶ��̴��� Player �±װ� �ְ�, �ݶ��̴��� ���� ���� �� �÷��̾� ������
        if (other.CompareTag("Player"))
        {
            GameManager.instance.GetComponent<GameManager>().Player_damage(0.5f);
        }
    }
}
