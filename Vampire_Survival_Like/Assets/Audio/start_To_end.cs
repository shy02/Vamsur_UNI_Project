using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_To_end : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        AudioManager.A_instance.PlayBgm(true);
    }
    private void OnDestroy()
    {
        AudioManager.A_instance.PlayBgm(false);
    }
    private void OnDisable()
    {
        AudioManager.A_instance.PlayBgm(false);

    }
}
