using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer_Manager : MonoBehaviour
{
    public GameObject GM;
    public float GameTime_sec = 0;
    public int GameTime_H = 0;
    public Text TimeText;
    public GameObject Timer_UI;
    
    void Start()
    {
        Timer_UI.SetActive(true);
        gameObject.GetComponent<Timer_Manager>().enabled = true;
    }
    // Update is called once per frameS
    void Update()
    {
        if(GameTime_H >= 5){
            gameObject.GetComponent<Timer_Manager>().enabled = false;
            Timer_UI.SetActive(false);
            GM.GetComponent<GameManager>().Survied();
            
        }
        GameTime_sec += Time.deltaTime;
        if(GameTime_sec >= 60f){
            GameTime_H++;
            GameTime_sec = 0;
        }
        TimeText.text = string.Format("{0:D2}:{1:D2}",GameTime_H,(int)GameTime_sec);
    }
}
