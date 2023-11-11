using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_effect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BOMB", 0.3f);
    }

    void BOMB(){
        Destroy(gameObject);
    }
}
