
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
    public float coolTime;
    public GameObject Data;
    private Transform Book;

    private float LastLevel = 0;

    void Start()
    {
        speed = 150;
        Batch();
    }

    void Update()
    {
        transform.Rotate(Vector3.back * speed * Time.deltaTime);

        if(LastLevel != Data.GetComponent<DataManager>().skill[4].Level){
            Debug.Log("레벨바뀜");
            Transform[] childList = gameObject.GetComponentsInChildren<Transform>();
            if(childList != null){
                for(int i =1; i < childList.Length; i++){
                    if(childList[i] != transform) Destroy(childList[i].gameObject);
                }
            }
            SkillSet(Data.GetComponent<DataManager>().skill[4].Level);
            Batch();
            LastLevel = Data.GetComponent<DataManager>().skill[4].Level;
        }
    }
    
    void Batch()
    {
        for (int index = 0; index < count; index++)
        {
            Book = GameManager.instance.pool.Get(prefabId).transform;
            Book.parent = transform;

            Vector3 rotVec = Vector3.forward * 360 * index / count;
            Book.Rotate(rotVec);
            Book.Translate(Book.up * 1.5f, Space.World);
        }
    }

    public void SkillSet(float lv){
        switch(lv){
            case 1: case 2: case 3:
            count = 1;
            break;
            case 4: case 5:
            count = 2;
            break;
            case 6: case 7:
            count = 3;
            break;
            case 8:
            count = 4;
            break;
            default:
            break;
        }
    }
}
