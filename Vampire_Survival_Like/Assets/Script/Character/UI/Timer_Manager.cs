using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer_Manager : MonoBehaviour
{
    public float GameTime_sec = 0;
    public int GameTime_H = 0;
    public bool isBossdead = false;
    public Text TimeText;
    public GameObject Timer_UI;
    public GameObject GM;
    
    void Start()
    {
        Timer_UI.SetActive(true);
        gameObject.GetComponent<Timer_Manager>().enabled = true;
    }
    // Update is called once per frameS
    void Update()
    {
        if (!GameManager.instance.isLive)
            return;

        if (GameTime_H >= 5){
            gameObject.GetComponent<Timer_Manager>().enabled = false;
            Timer_UI.SetActive(false);
            GM.GetComponent<GameManager>().Survied();   
        }
        if(GameTime_H == 2 && !isBossdead){
            Debug.Log("보스출현");
            GM.GetComponent<GameManager>().OnBlock();
            if(GameTime_sec > 30){
                GM.GetComponent<GameManager>().OffBlock();
                isBossdead = true;
            }
        }
        if(GameTime_H == 3 && isBossdead){isBossdead = false;}

        if(GameTime_H == 4 && !isBossdead){
            Debug.Log("보스출현");
            GM.GetComponent<GameManager>().OnBlock();
            if(GameTime_sec > 30){
                GM.GetComponent<GameManager>().OffBlock();
                isBossdead = true;
            }
        }
        GameTime_sec += Time.deltaTime;
        if(GameTime_sec >= 60f){
            GameTime_H++;
            GameTime_sec = 0;
        }
        TimeText.text = string.Format("{0:D2}:{1:D2}",GameTime_H,(int)GameTime_sec);
    }
}
