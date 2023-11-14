using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSkill : MonoBehaviour
{
    public GameObject data;
    public GameObject skill1;
    public GameObject skill2;
    public GameObject skill3;
    public GameObject skill4;
    public GameObject skill5;
    public GameObject skill6;
    public GameObject skill7;
    public GameObject skill8;
    // Update is called once per frame
    void Update()
    {
        //권총 장갑
        if(data.GetComponent<DataManager>().skill[0].Level == 8 && data.GetComponent<DataManager>().skill[8].Level == 1){
           skill1.GetComponent<PlayerAttack>().isFinal = true;
        }
        //에너지드링크 갑옷
        if(data.GetComponent<DataManager>().skill[1].Level == 8 && data.GetComponent<DataManager>().skill[10].Level == 1){
            skill2.GetComponent<EnergyDrink>().isFinal = true;
        }
        //간식 시금치
        if(data.GetComponent<DataManager>().skill[2].Level == 8 && data.GetComponent<DataManager>().skill[9].Level == 1){
            skill3.GetComponent<AttackPlayer_Snack>().isFinal = true;
        }
        //책 비급서
        if(data.GetComponent<DataManager>().skill[4].Level == 8 && data.GetComponent<DataManager>().skill[11].Level == 1){
            skill4.GetComponent<Book>().isFinal = true;
        }
        //폭죽 건전지
        if(data.GetComponent<DataManager>().skill[5].Level == 8 && data.GetComponent<DataManager>().skill[12].Level == 1){
            skill5.GetComponent<Bomb>().isFinal = true;
        }
        //스마트폰 사탕
        if(data.GetComponent<DataManager>().skill[3].Level == 8 && data.GetComponent<DataManager>().skill[13].Level == 1){
            skill6.GetComponent<SmartBoom>().isFinal = true;
        }
        //강아지 껌
        if(data.GetComponent<DataManager>().skill[6].Level == 8 && data.GetComponent<DataManager>().skill[14].Level == 1){
            skill7.GetComponent<Find_Enermy>().isFinal = true;
        }
        //바나나 컴퓨터
        if(data.GetComponent<DataManager>().skill[7].Level == 8 && data.GetComponent<DataManager>().skill[15].Level == 1){
            skill8.GetComponent<Banana>().isFinal = true;
        }
    }
}
