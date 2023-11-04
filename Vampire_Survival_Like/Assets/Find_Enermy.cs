using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Find_Enermy : MonoBehaviour
{
    public float rad = 0f;
    public LayerMask layer;
    public Collider2D[] colls;
    public Collider2D short_enemy;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        colls = Physics2D.OverlapCircleAll(transform.position, rad, layer);

        if(colls.Length > 0)
        {
            float short_distance = Vector3.Distance(transform.position, colls[0].transform.position);
            foreach(Collider2D col in colls)
            {
                float short_distance2 = Vector3.Distance(transform.position, col.transform.position);
                if(short_distance > short_distance2){
                    short_distance = short_distance2;
                    short_enemy = col;
                }
            }
        }
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rad);
    }
}
