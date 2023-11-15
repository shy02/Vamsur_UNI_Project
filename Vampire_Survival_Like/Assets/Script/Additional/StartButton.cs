using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void start()
    {
        SceneManager.LoadScene("Stage1");
        AudioManager.A_instance.PlaySfx(AudioManager.Sfx.select);
    }
}
