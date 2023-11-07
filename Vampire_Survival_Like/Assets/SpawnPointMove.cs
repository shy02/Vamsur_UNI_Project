using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointMove : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    private Transform selfpoint;

    void Start(){
        selfpoint = gameObject.transform;
    }
    void Update()
    {
        point1.position = new Vector3(selfpoint.position.x + 12, selfpoint.position.y + 7, 0);
        point2.position = new Vector3(selfpoint.position.x - 12, selfpoint.position.y + 7, 0);
        point3.position = new Vector3(selfpoint.position.x + 12, selfpoint.position.y - 7, 0);
        point4.position = new Vector3(selfpoint.position.x - 12, selfpoint.position.y - 7, 0);
    }
}
