using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class GameOption : MonoBehaviour
{
    RectTransform rect;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public void show()
    {
        rect.localScale = Vector3.one;
    }

    public void hide()
    {
        rect.localScale = Vector3.zero;
    }
}
