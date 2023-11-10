using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanaSpawner : MonoBehaviour
{
    public int Bana_num = 0;       // 생성된 바나나의 수를 추적하는 변수
    public int maxNum;
    public float time;
    public float coolTime;
    public float dmg;
    public float slowrate;
    public Transform p1;           // 생성 위치 중 하나
    public Transform p2;           // 생성 위치 중 하나
    public GameObject Banana_prefab;  // 생성할 바나나 프리팹
    public GameObject DataManager;
    void Update()
    {
        time += Time.deltaTime;

        if (time >= coolTime)
        {
            if (Bana_num < maxNum)
            {
                GameObject clone = Instantiate(Banana_prefab, new Vector3(Random.Range(p1.position.x, p2.position.x), Random.Range(p1.position.y, p2.position.y), Random.Range(p1.position.z, p2.position.z)), Quaternion.identity);
                clone.transform.parent = this.transform;
                SkillSet(DataManager.GetComponent<DataManager>().skill[7].Level, clone);
                
                clone.name = "Banana";
                clone.transform.localScale = Vector3.one * 1f;
                Bana_num++;
            }
            time = 0f;
        }
    }
    public void SkillSet(float lv, GameObject ba_clone){
        switch(lv)
        {
            case 1: case 2: case 3:
                maxNum = 2;
                break;

            case 4: case 5:
                maxNum = 3;
                break;
            
            case 6: case 7:
                maxNum = 4;
                break;
            
            case 8:
                maxNum = 5;
                break;

            default:
                break;
        }

        coolTime = 4.5f - 0.21f * (lv -1);
        dmg = 20f + 5.7f * (lv-1);
        slowrate = 30f + 3f * (lv-1);
        ba_clone.GetComponent<Banana>().Damage = dmg;
        ba_clone.GetComponent<Banana>().slowFactor = slowrate;
    }
    public void minusNum()
    {
        Bana_num--;
        // 바나나 수를 감소시키는 메서드
    }
}
