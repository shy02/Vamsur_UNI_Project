using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp_Area : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown("e") == true)
        {
            gameObject.GetComponent<CircleCollider2D>().radius = 10;
        }*/
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Exp"))
        {
            other.transform.parent = gameObject.transform.parent;
            other.GetComponent<Exp>().isclose = true;
            //Debug.Log(gameObject.transform.parent);
        }
    }
}
