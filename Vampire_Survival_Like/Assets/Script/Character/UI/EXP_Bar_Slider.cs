using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXP_Bar_Slider : MonoBehaviour
{
    public Slider EXP_Slider;
    private float Max_EXP = 100f;
    private float recently_Exp = 0f;
    private int LV = 0;

    // Update is called once per frame
    void Update()
    {
        recently_Exp += 2 * Time.deltaTime;
        if(recently_Exp < Max_EXP)EXP_Slider.value = recently_Exp / Max_EXP;
        if(recently_Exp > Max_EXP){
            EXP_Slider.value = 0;
            recently_Exp = 0;
            LV++;
            Max_EXP += 10*(LV/2);
            Debug.Log("Level : " + LV);
        }
        
    }
}
