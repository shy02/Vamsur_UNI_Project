using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public GameObject Data;
    public GameObject GM;
    public GameObject op1;
    public GameObject op2;
    public GameObject op3;

    public List<int>Num = new List<int>(){0,1,2,3,4,5,6,7,8,9};
    private int[] ran = new int[3];
    private int index;
    // Start is called before the first frame update
    void Awake()
    {
        Random_Num(0);
        Random_Num(1);
        Random_Num(2);

        Num.Add(ran[0]);
        Num.Add(ran[1]);
        Num.Add(ran[2]);

        Option_Setting(op1, 0);//op1 setting
        Option_Setting(op2, 1);//op2 setting
        Option_Setting(op3, 2);//op3 setting
    }

    public void Random_Num(int n){
        index = Random.Range(0, Num.Count);
        ran[n] = Num[index];
        Num.RemoveAt(index);
    }
    public void Option_Setting(GameObject obj, int num){
        obj.transform.GetChild(0).GetComponent<Image>().sprite = Data.GetComponent<DataManager>().skill[ran[num]].skill_Icon;
        obj.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = Data.GetComponent<DataManager>().skill[ran[num]].explain;
    }

    public int GetRan(int index){
        return ran[index];
    }
}
