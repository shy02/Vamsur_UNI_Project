using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public GameObject Data;
    public GameObject op1;
    public GameObject op2;
    public GameObject op3;
    public GameObject SkillManager;

    public List<int>Num = new List<int>(){0,1,2,3,4,5,6,7,8,9};
    private static int[] ran = new int[3];
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        Data = GameObject.Find("Manager").transform.GetChild(2).gameObject;
        SkillManager = GameObject.Find("Manager").transform.GetChild(1).gameObject;
        Random_Num(0);
        Random_Num(1);
        Random_Num(2);

        Num.Add(ran[0]);
        Num.Add(ran[1]);
        Num.Add(ran[2]);

        Option_Setting(op1, 0);//op1 setting
        Option_Setting(op2, 1);//op2 setting
        Option_Setting(op3, 2);//op3 setting

        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
        AudioManager.instance.EffectBgm(true);
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

    public int GetRan(int i){
        Debug.Log(ran[0]);
        Debug.Log(ran[1]);
        Debug.Log(ran[2]);
        return ran[i];
    }

    public void Button1Click(){
        SkillManager.GetComponent<SkillManager>().SelectOp1();
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Hit);
        AudioManager.instance.EffectBgm(false);
    }
    public void Button2Click(){
        SkillManager.GetComponent<SkillManager>().SelectOp2();
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Hit);
        AudioManager.instance.EffectBgm(false);
    }
    public void Button3Click(){
        SkillManager.GetComponent<SkillManager>().SelectOp3();
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Hit);
        AudioManager.instance.EffectBgm(false);
    }
}
