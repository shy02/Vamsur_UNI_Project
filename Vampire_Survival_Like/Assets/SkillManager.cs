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
        SelectFunction();
    }
    
    public void SelectOp2(){
        index = Upgrade.GetComponent<UpgradeUI>().GetRan(1);
        SelectFunction();
    }
    
    public void SelectOp3(){
        index = Upgrade.GetComponent<UpgradeUI>().GetRan(2);
        SelectFunction();
    }

    public void SelectFunction(){

        if(!Data.GetComponent<DataManager>().skill[index].isFirst){
        GameObject SkillUI = Instantiate(Up);
        if(index >= 8){
            SkillUI.transform.SetParent(BuffLayOut.transform);
        }
        else{
            SkillUI.transform.SetParent(SkillLayOut.transform);
        }
        Data.GetComponent<DataManager>().skill[index].SkillObject.SetActive(true);
        SkillUI.GetComponent<Chage_Icon_Image>().setIcon(Data.GetComponent<DataManager>().skill[index].skill_Icon);
        Data.GetComponent<DataManager>().skill[index].isFirst = true;
        }
        Data.GetComponent<DataManager>().skill[index].Level++;
        Destroy(Ui);
        GM.GetComponent<Pause_>().Pause();
    }

}
