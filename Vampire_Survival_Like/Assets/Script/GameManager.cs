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
    public GameObject Timer;
    public int DeadNum = 0;
    public int bossnum = 1;
    public int stagenum = 1;

    public bool bossisdead = false;
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
        if (Player_HP + player.gameObject.GetComponent<Player_State>().HP <= 30 && !isDangerous)
        {
            isDangerous = true;
            Danger_UI.GetComponent<Dangerous_UI>().Danger();
        }
        if (Player_HP + player.gameObject.GetComponent<Player_State>().HP > (Player_HP + player.gameObject.GetComponent<Player_State>().HP) / 100 * 30 && isDangerous)
        {
            isDangerous = false;
            Danger_UI.GetComponent<Dangerous_UI>().NoDanger();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<Pause_>().Pause();
        }
        if (bossisdead)
        {
            bossisdead = false;
            OffBlock();
            Timer.GetComponent<Timer_Manager>().Bossishere = false;
            if(bossnum == 5)
            {
                Enemy.SetActive(true);
                Timer.GetComponent<Timer_Manager>().enabled = true;
            }
            bossnum += 1;
        }
    }

    public void Player_damage(float dmg)
    {
        Player_HP -= dmg;
        AudioManager.A_instance.PlaySfx(AudioManager.Sfx.c_hit);

    }
    public float getPlayer_HP(float hp)
    {
        hp = Player_HP;
        return hp;
    }

    public void gameOver()
    {
        Enemy.SetActive(false);
        GameOver_UI.SetActive(true);
    }

    public void Survied()
    {
        Enemy.SetActive(false);
        Survied_UI.SetActive(true);
    }
    public void RestartClick()
    {
        if (stagenum < 5)
        {
            stagenum++;
            SceneManager.LoadScene("Stage" + stagenum);
            Timer.GetComponent<Timer_Manager>().enabled = true;
        }
        else
        {
            SceneManager.LoadScene("Ending");
        }

    }
    public void OnBlock()
    {
        Block_Player.SetActive(true);
        Block_Player.transform.SetParent(null);
    }
    public void OffBlock()
    {
        Block_Player.transform.parent = player.transform;
        Block_Player.transform.localPosition = Vector3.zero;
        Block_Player.transform.localScale = Vector3.one;
        Block_Player.SetActive(false);
    }
    public void SkillTime()
    {
        SkillManager.GetComponent<SkillManager>().StartUI();
    }
}