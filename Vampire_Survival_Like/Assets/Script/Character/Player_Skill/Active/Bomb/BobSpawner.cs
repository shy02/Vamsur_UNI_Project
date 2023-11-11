using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobSpawner : MonoBehaviour
{
    public int Bomb_num = 0;
    public int maxNum;
    public Transform p1;
    public Transform p2;
    public GameObject Bomb_prefab;
    public GameObject DataManager;

    public float MaxTime;
    public float Timer;
    private float LV;
    
        void Update(){
            Timer += Time.deltaTime;
           LV = DataManager.GetComponent<DataManager>().skill[5].Level;
        if(Timer >= 4.5 - ((4.5/100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().CoolTime)){     
            if(Bomb_num < maxNum){
            Instantiate(Bomb_prefab, new Vector3(Random.Range(p1.position.x, p2.position.x), Random.Range(p1.position.y, p2.position.y), Random.Range(p1.position.z, p2.position.z)), Quaternion.identity);
            Bomb_num++;
            }
            Timer = 0;
        }
    }

    public void minusNum(){
        Bomb_num--;
    }

    public void SkillSet(float lv){
        switch(lv){
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
    }
}
