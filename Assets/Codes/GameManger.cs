using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;
    public PoolManger pool;
    public Player player;


void Awake()
{
    instance = this;
}
}