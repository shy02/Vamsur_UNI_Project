using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gansic : MonoBehaviour
{

    public int id;
    public int prefabId;
    public float damage;
    public float count;

    // Start is called before the first frame update
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
            for(int index = 0; index < count; index ++) {
            Transform gansic = GameManager.instance.Player_pool.Get(prefabId).transform;
            gansic.parent = transform;
            gansic.GetComponent<Skill>().Init(damage, -1); // -1 is infinity per. 무한 공

            
            }

    }

}
