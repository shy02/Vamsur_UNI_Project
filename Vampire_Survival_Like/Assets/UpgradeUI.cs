using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public GameObject Skill;
    public GameObject GM;
    public GameObject op1;
    public GameObject op2;
    public GameObject op3;

    public List<int>Ran_num = new List<int>(){0,1,2,3,4,5,6,7,8,9};
    private int[] ran = new int[3];
    // Start is called before the first frame update
    void Start()
    {
        ran[0] = Random.Range(0, Ran_num.Count);
        Ran_num.RemoveAt(ran[0]);
        ran[1] = Random.Range(0, Ran_num.Count);
        Ran_num.RemoveAt(ran[1]);
        ran[2] = Random.Range(0, Ran_num.Count);

        Ran_num.Add(ran[0]);
        Ran_num.Add(ran[1]);
    }

    // Update is called once per frame
    void Update()
    {    
    }
}
