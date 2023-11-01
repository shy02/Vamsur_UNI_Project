
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;


    void Start()
    {
        Init();
    }

    void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            default:
                break;
        }
    }
    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = 150;
                Batch();
                break;
            default:
                break;
        }
    }
    void Batch()
    {
        for (int index = 0; index < count; index++)
        {
            Transform Book = GameManager.instance.pool.Get(prefabId).transform;
            Book.parent = transform;

            Vector3 rotVec = Vector3.forward * 360 * index / count;
            Book.Rotate(rotVec);
            Book.Translate(Book.up * 1.5f, Space.World);

            Book.GetComponent<Book>().Init(damage, -1); // -1 is infinity per. 무한 공

        }
    }
}
