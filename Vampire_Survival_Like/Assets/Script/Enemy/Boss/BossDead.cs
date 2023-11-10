using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDead : MonoBehaviour
{
    public void Dead_(string stage_name){
        SceneManager.LoadScene(stage_name);
    }
}
