using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_To_End : MonoBehaviour
{
    bool a;
    private void Start()
    {
        AudioManager.A_instance.PlayBgm(a);
    }
    private void OnEnable()
    {
        a = true;
        Debug.Log("BGM Start");
        AudioManager.A_instance.PlayBgm(a);
    }
    // Start is called before the first frame update


    private void OnDisable()
    {
        a = false;
        Debug.Log("BGM End");
        AudioManager.A_instance.PlayBgm(a);

    }
}
