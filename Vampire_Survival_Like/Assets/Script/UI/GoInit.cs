using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoInit : MonoBehaviour
{
    public void restart(){
        AudioManager.A_instance.PlaySfx(AudioManager.Sfx.select);
        Destroy(GameObject.Find("DontDestroyOnLoad"));
        SceneManager.LoadScene("Init");
    }
}
