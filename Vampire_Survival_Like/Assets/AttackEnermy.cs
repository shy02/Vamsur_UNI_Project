using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnermy : MonoBehaviour
{
    Find_Enermy find;
    public int Speed;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        find = gameObject.GetComponent<Find_Enermy>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(find.short_enemy){
            Invoke("RunAway", 1f);
        }
        else{
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Speed/2*Time.deltaTime);
            }
    }
    public void RunAway(){
        transform.position = Vector3.MoveTowards(transform.position, find.short_enemy.transform.position, Speed*Time.deltaTime);
        Invoke("Return", 5f);
    }
    public void Return(){
        transform.position = player.transform.position;
    }
    }


