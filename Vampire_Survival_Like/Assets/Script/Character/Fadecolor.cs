using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadecolor : MonoBehaviour
{
    SpriteRenderer sr;
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        sr = go.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("r"))
        sr.material.color = Color.red;
    }
}
