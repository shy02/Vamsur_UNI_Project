using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_BAR_Slider : MonoBehaviour
{
    public GameObject GM;
    private float maxhp = 100f;
    private float currenthp;
    public Slider HP_bar;
    void Update()
    {
        currenthp = GM.GetComponent<GameManager>().getPlayer_HP(currenthp);
        if(currenthp > 0) HP_bar.value = currenthp/maxhp;
        if(currenthp <= 0) GM.GetComponent<GameManager>().gameOver();
        
    }
}
