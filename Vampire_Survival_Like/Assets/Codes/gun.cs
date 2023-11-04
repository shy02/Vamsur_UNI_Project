using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage;
    public int per;
    public float speed;

    public void Init(float damage, int per)
    {
        this.damage = damage;
        this.per = per;
    }


    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroygun", 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void Destroygun()
    {
        Destroy(gameObject);
    }
}
