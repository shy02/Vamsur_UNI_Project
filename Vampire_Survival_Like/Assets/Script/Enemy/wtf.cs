using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wtf : MonoBehaviour
{
    public float timer;
    public BoxCollider2D area; // 근접 공격 범위


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        area.enabled = false; // 공격 범위 비활성화

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > 5)
        {
            timer = 0;
            StopCoroutine("atk_area"); //코루틴 함수로 공격범위 제어
            StartCoroutine("atk_area");
        }

    }

    IEnumerator atk_area()
    {
        area.enabled = true; // 공격범위 활성화
        yield return new WaitForSeconds(1f); // 2초후 비활성화
        area.enabled = false;
    }
}
