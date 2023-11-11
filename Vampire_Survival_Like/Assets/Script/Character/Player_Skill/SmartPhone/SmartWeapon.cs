using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartWeapon : MonoBehaviour
{
    Player player;

    /// <summary>
    /// ///////////////////////////////////////
    /// </summary>
    public GameObject smart;

    public Transform pos;
    public float cooltime;
    public DataManager data;
    private float lv;
    private float curtime;
    private float dmg;
    private int per;
    private int num;

    
    public Rigidbody2D rb;
    float randomX, randomY;
    
    

    void Awake()
    {
    }
    void Update()
    {
        //
        rb = GetComponent<Rigidbody2D>();
        randomX = Random.Range(-1f, 1f);                 //랜덤값
        randomY = Random.Range(-1f, 1f);
        Vector2 len = new Vector2(randomX, randomY).normalized;
        
       // Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; // 마우스 방향 바라보기
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);

        
        curtime += Time.deltaTime;
        lv = data.skill[0].Level;
        SkillSet(lv);
        if (curtime >= cooltime )
        {
            /*
            Vector3 targetPos = player.scanner.nearestTarget.position;
            Vector3 dir = targetPos - transform.position;
            dir = dir.normalized;
            transform.rotation = Quaternion.Euler(Vector3.up, 0, z);
            Instantiate(smart, pos.position, transform.rotation);
*/
            
            smart.GetComponent<Smart>().Init(dmg, per);
            shot();
            for (int i = 0; i < num - 1; i++)
            {
                Invoke("shot", 0.1f);
            }

            curtime = 0;
        }

    }


    void shot()
    {
        if (!GameManager.instance.player.scanner.nearestTarget)
            return;
        
        Instantiate(smart, GameManager.instance.player.gameObject.transform.position, transform.rotation);
    }
    
    
    void SkillSet(float lv)
    {
        dmg = 1.0f + 1.5f * (lv - 1);
        switch (lv)
        {
            case 1:
            case 2:
                num = 1;
                break;
            case 3:
            case 4:
                num = 2;
                break;
            case 5:
                num = 3;
                break;
            case 6:
                num = 4;
                break;
            case 7:
                num = 5;
                break;
            case 8:
                num = 6;
                break;
        }

        switch (lv)
        {
            case 1:
            case 2:
            case 3:
                per = 50;
                break;
            case 4:
            case 5:
            case 6:
                per = 70;
                break;
            case 7:
            case 8:
                per = 100;
                break;
        }
    }
}
