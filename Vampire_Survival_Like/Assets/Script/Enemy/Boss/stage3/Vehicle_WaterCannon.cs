using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle_WaterCannon : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D target,water_cannon;
    float speed = 25f;
    
    void Start()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        water_cannon = GetComponent<Rigidbody2D>();
        Vector2 director = target.position - water_cannon.position;
        water_cannon.AddForce(water_cannon.position + director.normalized * speed * Time.deltaTime);
        water_cannon.velocity = Vector2.zero;
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale += new Vector3(0, 0.05f, 0);
        Vector2 director = target.position - water_cannon.position;
        water_cannon.MovePosition(water_cannon.position+director.normalized * speed * Time.deltaTime);
    }
}
