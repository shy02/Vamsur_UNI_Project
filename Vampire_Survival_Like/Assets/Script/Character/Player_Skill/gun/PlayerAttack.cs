using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject gun;
    public Transform pos;
    public float cooltime;
    public DataManager data;
    private float lv;
    private float curtime;
    private float dmg;
    private int per;
    private int num;
    void Update()
    {

        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;// 마우스 방향 바라보기
        float z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,z);

        curtime += Time.deltaTime;
        lv = data.skill[0].Level;
        SkillSet(lv);
        if (curtime >= cooltime)
        {
                gun.GetComponent<gun>().Init(dmg,per);
                shot();
                for(int i = 0; i < num-1; i++){
                    Invoke("shot", 0.1f);
                }
                curtime = 0;
        }

    }


    void shot(){
    Instantiate(gun,pos.position,transform.rotation);
    }

    void SkillSet(float lv){
        dmg = 6.5f + 1.5f*(lv-1);
        switch(lv){//투사체 수
            case 1: case 2:
                num = 1;
                break;
            case 3: case 4:
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
    switch(lv){//관통
        case 1: case 2: case 3:
                per = 1;
                break;
        case 4: case 5: case 6:
                per = 2;
                break;
        case 7: case 8:
                per = 3;
                break;
    }
}
}
