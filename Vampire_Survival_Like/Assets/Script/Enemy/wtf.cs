using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wtf : MonoBehaviour
{
    public float timer;
    public BoxCollider2D area; // ���� ���� ����


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        area.enabled = false; // ���� ���� ��Ȱ��ȭ

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > 5)
        {
            timer = 0;
            StopCoroutine("atk_area"); //�ڷ�ƾ �Լ��� ���ݹ��� ����
            StartCoroutine("atk_area");
        }

    }

    IEnumerator atk_area()
    {
        area.enabled = true; // ���ݹ��� Ȱ��ȭ
        yield return new WaitForSeconds(1f); // 2���� ��Ȱ��ȭ
        area.enabled = false;
    }
}
