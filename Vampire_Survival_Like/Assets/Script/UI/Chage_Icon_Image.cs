using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chage_Icon_Image : MonoBehaviour
{
    public void setIcon(Sprite Icon){
        gameObject.GetComponent<Image>().sprite = Icon;
    }
}
