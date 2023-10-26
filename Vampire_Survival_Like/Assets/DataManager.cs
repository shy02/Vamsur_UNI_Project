using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class DataManager : MonoBehaviour
{
    [Serializable]
    public struct Skills
    {
        public int id;
        public string name;
        public string explain;
        public int Level;
        public Sprite skill_Icon;
    }

    [SerializeField]
    public Skills[] skill;
}
