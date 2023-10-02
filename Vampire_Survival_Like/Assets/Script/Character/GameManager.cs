using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PoolManger pool;
    public Player player;
    public float Player_HP = 100f;
    public GameObject GameOver_UI;
    public GameObject Survied_UI;
    public GameObject Enemy;

void Awake()
{
    instance = this;
    GameOver_UI.SetActive(false);
    Survied_UI.SetActive(false);
}

public void Player_damage(){
    Player_HP--;
    Debug.Log(Player_HP);
}
public float getPlayer_HP(float hp){
    hp = Player_HP;
    return hp;
}

public void gameOver(){
    Enemy.SetActive(false);
    GameOver_UI.SetActive(true);
}

public void Survied(){
    Enemy.SetActive(false);
    Survied_UI.SetActive(true);
}
public void RestartClick(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}