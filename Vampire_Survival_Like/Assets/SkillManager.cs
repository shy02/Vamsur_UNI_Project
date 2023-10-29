using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public GameObject Up;
    public GameObject Upgrade;
    public GameObject Data;
    public GameObject SkillLayOut;
    public GameObject BuffLayOut;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        Upgrade.SetActive(true);
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
        GameObject SkillUI = Instantiate(Up);
        if(index >= 8){
            SkillUI.transform.SetParent(BuffLayOut.transform);
        }
        else{
            SkillUI.transform.SetParent(SkillLayOut.transform);
        }
        Data.GetComponent<DataManager>().skill[index].SkillObject.SetActive(true);
        Upgrade.SetActive(false);
    }
}
