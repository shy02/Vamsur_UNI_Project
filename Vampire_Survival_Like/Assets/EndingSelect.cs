using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSelect : MonoBehaviour
{
    public static EndingSelect Endinginstance;
    public GameObject HappyEnding_Image;
    public GameObject BadEnding_Image;
    public GameObject Poppy;
    public void Start(){
        Endinginstance = this;
    }
    public void endingSelct()
    {
        Poppy = GameObject.Find("DontDestroyOnLoad").transform.GetChild(1).GetChild(1).GetChild(3).gameObject;
        if(Poppy.GetComponent<Find_Enermy>().isFinal){
            SceneManager.LoadScene("Ending");
        }else{
            SceneManager.LoadScene("SadEndingCut 1");
        }
        
    }
}
