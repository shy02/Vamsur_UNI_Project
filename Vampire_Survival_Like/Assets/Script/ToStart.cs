using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStart : MonoBehaviour
{
    // Start is called before the first frame update
    public void start()
    {
        SceneManager.LoadScene("Init");
    }
    }