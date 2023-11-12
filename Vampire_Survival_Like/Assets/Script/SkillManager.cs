using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public GameObject GM;
    public GameObject Up;
    public GameObject Upgrade;
    public GameObject Data;
    public GameObject SkillLayOut;
    public GameObject BuffLayOut;
    public GameObject Ui;
    public int index;
    private int Active = 1;
    private int Passive = 0;
    private bool isActiveClear;
    private bool isPassiveClear;
    private float LV;
    // Start is called before the first frame update
    void Start()
    {
        Ui = Instantiate(Upgrade);
        GM.GetComponent<Pause_>().Pause();
    }
    
    public void StartUI(){
        Ui = Instantiate(Upgrade);
    }

    public void SelectOp1(){
        index = Upgrade.GetComponent<UpgradeUI>().GetRan(0);
        LevelUP(index);
        SelectFunction();
    }
    public void SelectOp2(){
        index = Upgrade.GetComponent<UpgradeUI>().GetRan(1);
        LevelUP(index);
        SelectFunction();
    }
    
    public void SelectOp3(){
        index = Upgrade.GetComponent<UpgradeUI>().GetRan(2);
        LevelUP(index);
        SelectFunction();
    }

    public void SelectFunction(){
        
        if(!Data.GetComponent<DataManager>().skill[index].isFirst){
        GameObject SkillUI = Instantiate(Up);

        if(index >= 8){
            SkillUI.transform.SetParent(BuffLayOut.transform);
            Passive++;
        }
        else{
            SkillUI.transform.SetParent(SkillLayOut.transform);
            Active++;
            Debug.Log(Active);
        }
        if(Active == 5 && !isActiveClear){
            for(int i = 0; i <UpgradeUI.Num.Count/2 +1; i++){
                if(!Data.GetComponent<DataManager>().skill[i].isFirst){
                    UpgradeUI.Num.Remove(i);
                }
            }
            isActiveClear = true;
        }

        if(Passive == 5 && !isPassiveClear){
            for(int i = UpgradeUI.Num.Count/2 +1; i < UpgradeUI.Num.Count; i++){
                if(!Data.GetComponent<DataManager>().skill[i].isFirst){
                    UpgradeUI.Num.Remove(i);
                }
            }
            isActiveClear = true;
        }
        Data.GetComponent<DataManager>().skill[index].SkillObject.SetActive(true);
        SkillUI.GetComponent<Chage_Icon_Image>().setIcon(Data.GetComponent<DataManager>().skill[index].skill_Icon);
        Data.GetComponent<DataManager>().skill[index].isFirst = true;
        }

        Destroy(Ui);
        GM.GetComponent<Pause_>().Pause();
    }

    public void LevelUP(int index){
        Data.GetComponent<DataManager>().skill[index].Level++;
        LV = Data.GetComponent<DataManager>().skill[index].Level;
        if(index < 8){
            if(LV == 8 && UpgradeUI.Num.Contains(index)){
                UpgradeUI.Num.Remove(index);
            }
        }else{
            if(LV == 5 && UpgradeUI.Num.Contains(index)){
                UpgradeUI.Num.Remove(index);
            } 
        }
    }
}
