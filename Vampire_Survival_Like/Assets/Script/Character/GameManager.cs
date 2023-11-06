using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Security;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isLive;
    public PoolManager pool;
    public PoolManager Player_pool;
    public Player player;
    public float Player_HP = 100f;
    public GameObject GameOver_UI;
    public GameObject Survied_UI;
    public GameObject Danger_UI;
    public GameObject Enemy;
    public GameObject Block_Player;
    public string SceneToLoad;


    private bool isDangerous = false;

    void Awake()
    {
        instance = this;
        GameOver_UI.SetActive(false);
        Survied_UI.SetActive(false);
        Block_Player.SetActive(false);
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Sc_Play");
    }

    void Update()
    {
        if (!isLive)
            return;

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

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;

    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;

    }

}