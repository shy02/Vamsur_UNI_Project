using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXP_Bar_Slider : MonoBehaviour
{
    public Slider EXP_Slider;
    private float Max_EXP = 100f;
    private float recently_Exp = 0f;
    private int LV = 1;

    // Update is called once per frame
    void Start()
    {
        
    }
    void Update()
    {
        //recently_Exp += 2 * Time.deltaTime;

        if(recently_Exp < Max_EXP)EXP_Slider.value = recently_Exp / Max_EXP;

        if(recently_Exp > Max_EXP){
            GameManager.instance.SkillTime();
            EXP_Slider.value = 0;
            recently_Exp = 0;
            LV++;
            Max_EXP += 10*(LV/2);
            Debug.Log("Level : " + LV);
        }
        
    }
    public void Exp_Up()
    {
        recently_Exp += 10 * LV;
        recently_Exp += (recently_Exp /100) * GameManager.instance.player.gameObject.GetComponent<Player_State>().GetEXP;

    }
}
