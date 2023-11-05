using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public float Player_HP = 100f;
    public int stage = 0;
    public GameObject GameOver_UI;
    public GameObject Survied_UI;
    public GameObject Danger_UI;
    public GameObject EXP_UI;
    public GameObject Enemy;
    public GameObject Block_Player;
    public GameObject Skill_Manager;

    private bool isDangerous = false;

void Awake()
{
    instance = this;
    GameOver_UI.SetActive(false);
    Survied_UI.SetActive(false);
    Block_Player.SetActive(false);
}

void Update()
{
    if(Player_HP <= 30 && !isDangerous){
        isDangerous = true;
        Danger_UI.GetComponent<Dangerous_UI>().Danger();
    }
    if(Player_HP > 30 && isDangerous){
        isDangerous = false;
        Danger_UI.GetComponent<Dangerous_UI>().NoDanger();
    }
    if(Input.GetKeyDown(KeyCode.T)){
        gameObject.GetComponent<Pause_>().Pause();
    }
}

public void Player_damage(float damage){
        //Player_HP--;
        Player_HP = Player_HP - damage;
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
public void OnBlock(){
    Block_Player.SetActive(true);
    Block_Player.transform.SetParent(null);
}
public void OffBlock(){
    Block_Player.transform.parent = player.transform;
    Block_Player.transform.localPosition = Vector3.zero;
    Block_Player.transform.localScale = Vector3.one;
    Block_Player.SetActive(false);
}
public void SkillTime(){
    gameObject.GetComponent<Pause_>().nowPause = true;
    
}
}