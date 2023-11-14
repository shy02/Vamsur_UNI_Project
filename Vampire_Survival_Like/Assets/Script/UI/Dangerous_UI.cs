using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dangerous_UI : MonoBehaviour
{
    public bool isDangerous;
    private bool isfull =false;
    private float p;
    private Color color;
<<<<<<< HEAD
=======
    public GameObject gm;
>>>>>>> main

    void Start(){
        p = 0f;
        isDangerous = false;
        color = gameObject.GetComponent<Image>().color;
        color.a = p;
        gameObject.GetComponent<Image>().color = color;
        this.gameObject.SetActive(true);
    }
    void Update()
    { 
<<<<<<< HEAD
        if(!GameManager.instance.GetComponent<Pause_>().nowPause){   
=======
        if(!gm.GetComponent<Pause_>().nowPause){   
>>>>>>> main
            if(isDangerous){
            if(p < 1 && !isfull){
            p += 0.007f;
            color.a = p;
            gameObject.GetComponent<Image>().color = color;
            if(p >= 0.9) isfull = true;
            }
            if(isfull){
             p -= 0.007f;
             color.a = p;
             gameObject.GetComponent<Image>().color = color;
             if(p < 0.3) isfull = false;
            }
        }
        }
        
    }

    public void Danger(){
        p = 0f;
        isDangerous = true;
    }

    public void NoDanger(){
        isDangerous = false;
        p = 0f;
        gameObject.GetComponent<Image>().color = color;
    }
}
