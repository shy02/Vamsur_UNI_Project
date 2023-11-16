using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommandKey : MonoBehaviour
{
    [SerializeField]
    public GameObject[] ActiveSkill;


    private int stagenum;
    void Update()
    {
        //숫자1~8스킬 8까지 강화
        if(Input.GetKey(KeyCode.Alpha1)){

        }

        if(Input.GetKey(KeyCode.Alpha2)){

        }
        if(Input.GetKey(KeyCode.Alpha3)){
            
        }
        if(Input.GetKey(KeyCode.Alpha4)){
            
        }
        if(Input.GetKey(KeyCode.Alpha5)){
            
        }
        if(Input.GetKey(KeyCode.Alpha6)){
            
        }
        if(Input.GetKey(KeyCode.Alpha7)){
            
        }
        if(Input.GetKey(KeyCode.Alpha8)){
            
        }
        //1스테이지 보스 소환
        
        if(Input.GetKey(KeyCode.Q)){
            
        }
        //보스 죽이고 win 띄우기
        
        if(Input.GetKey(KeyCode.E)){
            
        }
        //스테이지 변경
        
        if(Input.GetKey(KeyCode.Less)){//전 스테이지
            this.stagenum = GameManager.instance.stagenum;
            Debug.Log(this.stagenum);
            if(this.stagenum > 0){
            this.stagenum--;
            GameManager.instance.stagenum = this.stagenum;
            SceneManager.LoadScene("Stage" + this.stagenum);
            }
        }
        if(Input.GetKey(KeyCode.Greater)){//후 스테이지
            this.stagenum = GameManager.instance.stagenum;
            Debug.Log(this.stagenum);
            if(this.stagenum < 5){
            this.stagenum++;
            GameManager.instance.stagenum = this.stagenum;
            SceneManager.LoadScene("Stage" + this.stagenum);
            }
        }
        //포피 최종진화 시키기
        if(Input.GetKey(KeyCode.R)){

        }
        //엔딩 가기
        if(Input.GetKey(KeyCode.T)){
            SceneManager.LoadScene("Ending");
        }
        //시작화면 가기
        if(Input.GetKey(KeyCode.Y)){

        }
        //이거 말고 더 쓸게 있을까?
    }
}
