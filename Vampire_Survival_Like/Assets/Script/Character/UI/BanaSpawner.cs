using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanaSpawner : MonoBehaviour
{
    public int Bana_num = 0;       // 생성된 바나나의 수를 추적하는 변수
    public int maxNum;             // 최대 생성 가능한 바나나 수
    public Transform p1;           // 생성 위치 중 하나
    public Transform p2;           // 생성 위치 중 하나
    public GameObject Banana_prefab;  // 생성할 바나나 프리팹

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (Bana_num < maxNum)
            {
                // "Z" 키가 눌렸고, 최대 생성 가능한 바나나 수보다 적을 경우에 아래 코드를 실행

                GameObject clone = Instantiate(Banana_prefab, transform.position, Quaternion.identity);
                // 바나나 프리팹을 현재 스포너 위치에 생성하고, clone 변수에 할당

                clone.name = "Banana";  // 생성된 바나나 오브젝트의 이름을 "Banana"로 설정
                clone.transform.localScale = Vector3.one * 1f;
                // 생성된 바나나 오브젝트의 크기를 초기 크기의 1배로 설정
            }
        }
    }

    public void minusNum()
    {
        Bana_num--;
        // 바나나 수를 감소시키는 메서드
    }
}
