using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    
    [Serializable]
    public struct Skills
    {
        public int id;
        public string name;
        public string explain;
        public float Level;
        public Sprite skill_Icon;
        public GameObject SkillObject;
        public bool isFirst;
    }
    [Serializable]
    public struct FinalSkill
    {
        public int id;
        public string name;
        public string explain;
        public Sprite skill_Icon;
        public GameObject finalObject;
        public GameObject Active;
        public GameObject Passive;
        public bool isFirst;
    }


    [SerializeField]
    public Skills[] skill;
    public FinalSkill[] final;
}
