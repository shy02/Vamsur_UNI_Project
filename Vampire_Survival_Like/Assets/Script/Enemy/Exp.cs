using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public bool isclose;
    float speed = 8;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isclose)
        {
            transform.position = Vector3.MoveTowards(transform.position,target.transform.position, speed * Time.deltaTime);
        }
    }
}
