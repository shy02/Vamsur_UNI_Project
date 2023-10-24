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
    
        void Update(){
            
        if(Input.GetKeyDown(KeyCode.A)){     
            if(Bomb_num < maxNum){
            Instantiate(Bomb_prefab, new Vector3(Random.Range(p1.position.x, p2.position.x), Random.Range(p1.position.y, p2.position.y), Random.Range(p1.position.z, p2.position.z)), Quaternion.identity);
            Bomb_num++;
            }
        }
    }

    public void minusNum(){
        Bomb_num--;
    }
}
