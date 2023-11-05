using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject gun;
    public Transform pos;
    public float cooltime;
    private float curtime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;// 마우스 방향 바라보기
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,z);

        curtime += Time.deltaTime;

        if (curtime >= cooltime)
        {

                Instantiate(gun,pos.position,transform.rotation);
                curtime = 0;
        }

    }
}
