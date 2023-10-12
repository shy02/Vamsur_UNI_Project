using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerTest0 player;

    void Awake()
    {
        instance = this;
    }

   
}
