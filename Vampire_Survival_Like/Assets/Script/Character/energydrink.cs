using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energydrink : MonoBehaviour
{
    
    public int id;
    public int prefabId;
    public float damage;
    
     void Start()
    {
        Init();
    }

    
    public void Init()
    {
        Batch();
    }
     void Batch()
    {
        
            Transform bullet =GameManager.instance.Player_pool.Get(prefabId).transform;
            bullet.parent = transform;          

            bullet.GetComponent<Skill>().Init(damage, -1); // -1 is infinity per. 무한 공
        
    }
    

}
