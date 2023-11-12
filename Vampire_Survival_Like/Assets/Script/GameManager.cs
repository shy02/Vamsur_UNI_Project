using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public PoolManager pool;
    public float Player_HP = 100f;
    public GameObject GameOver_UI;
    public GameObject Survied_UI;
    public GameObject Danger_UI;
    public GameObject EXP_UI;
    public GameObject Enemy;
    public GameObject Block_Player;
    public GameObject SkillManager;
    public GameObject DataManager;
    public GameObject DeadEnemyNum;
    public int DeadNum = 0;
    private int stagenum = 2;

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
    if(Player_HP + player.gameObject.GetComponent<Player_State>().HP <= 30 && !isDangerous){
        isDangerous = true;
        Danger_UI.GetComponent<Dangerous_UI>().Danger();
    }
    if(Player_HP + player.gameObject.GetComponent<Player_State>().HP > (Player_HP + player.gameObject.GetComponent<Player_State>().HP)/100 * 30 && isDangerous){
        isDangerous = false;
        Danger_UI.GetComponent<Dangerous_UI>().NoDanger();
    }
    if(Input.GetKeyDown(KeyCode.T)){
        gameObject.GetComponent<Pause_>().Pause();
    }
}

public void Player_damage(float dmg){
    Player_HP -= dmg;
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
    if(stagenum<=5){
    SceneManager.LoadScene("Stage" + stagenum);
    stagenum++;
    }
    else{
    SceneManager.LoadScene("Ending");
    }

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
<<<<<<< HEAD:Vampire_Survival_Like/Assets/Script/Character/GameManager.cs
    gameObject.GetComponent<Pause_>().nowPause = true;
    
=======
    gameObject.GetComponent<Pause_>().Pause();
    SkillManager.GetComponent<SkillManager>().StartUI();   
>>>>>>> 639c65b06df45023916c3820b45abd55947ebe0c:Vampire_Survival_Like/Assets/Script/GameManager.cs
}
}