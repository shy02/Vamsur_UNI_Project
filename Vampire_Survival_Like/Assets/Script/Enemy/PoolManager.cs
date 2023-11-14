using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform Book_Trans;
    public float Timer; // 쿨타임용
    public float coolTime; // 쿨타임
    public float Timer_;//지속시간 용
    public float StayTime; //지속시간
    public GameObject Book;
    public DataManager data;
    public bool isend = false;

    private float lv;

    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }

    }
    void Update(){
<<<<<<< HEAD
        if(data.skill[4].isFirst){
            lv = data.skill[4].Level;
            StayTime = 3f + 0.15f * (lv-1);
=======
        
        if(data.skill[4].isFirst){
            lv = data.skill[4].Level;
            StayTime = 3f + 0.15f * (lv-1);
            StayTime += (StayTime/100)*GameManager.instance.player.gameObject.GetComponent<Player_State>().WeaphoneTime;
>>>>>>> main
            Timer += Time.deltaTime;
            Timer_ += Time.deltaTime;

        if(Timer >= coolTime && isend){
            Book.SetActive(true);
            Timer = 0;
            Timer_ = 0;
            isend = false;
        }
        if(Timer_ >= StayTime && !isend){
            Book.SetActive(false);
            Timer = 0;
            Timer_ = 0;
            isend = true;
        }
        }
    }
    public GameObject Get(int index)
    {
        GameObject select = null;

            select = Instantiate(prefabs[index], Book_Trans);
            pools[index].Add(select);
        return select;
    }
}
