using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSelect : MonoBehaviour
{
    public GameObject HappyEnding_Image;
    public GameObject BadEnding_Image;
    public GameObject Poppy;
    void Start()
    {
        Poppy = GameObject.Find("DontDestroyOnLoad").transform.GetChild(1).GetChild(1).GetChild(3).gameObject;
        if(Poppy.GetComponent<Find_Enermy>().isFinal){
            HappyEnding_Image.SetActive(true);
        }else{
            BadEnding_Image.SetActive(true);
        }
        
    }
}
