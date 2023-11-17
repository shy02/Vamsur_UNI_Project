using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Image Panel;
    public Image Ending;
    public GameObject Restart;
    public GameObject Text;
    float time = 0f;
    float F_time = 3f;
    bool isend = false;
    void Start(){
        if(GameObject.Find("DontDestroyOnLoad")){
            Destroy(GameObject.Find("DontDestroyOnLoad"));
        }
        Invoke("FadeOut", 2f);
    }
    
    // 페이드 인 아웃
    /*public void FadeInFadeOut()
    {
        StartCoroutine(FadeInFadeOutFlow());
    }*/
    
    /*IEnumerator FadeInFadeOutFlow()
    {
        //검정으로 변해랏
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0f;

        yield return new WaitForSeconds(1f);
        
        //검정이 사라져랏
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null;
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInFlow());
    }
    
    
    IEnumerator FadeInFlow()
    {
        //검정으로 변해랏
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;
        alpha.a = 1;
 
        //검정이 사라져랏
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    //페이드 아웃은 본 영상에서 검은색으로*/

    public void FadeOut()
    {
        StartCoroutine(FadeOutFlow());
        Invoke("Active", 5f);
    }
    
    
    IEnumerator FadeOutFlow()
    {
        //검정으로 변해랏
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;
        alpha.a = 0;
        
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }

        Ending.gameObject.SetActive(true);
        time = 0f;
        Color Ealpha = Ending.color;
        alpha.a = 0;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / (F_time-2);
            Ealpha.a = Mathf.Lerp(0, 1, time);
            Ending.color = Ealpha;
            yield return null;
        }

        yield return null;
    }

    void Active(){
        Restart.SetActive(true);
        Text.SetActive(true);
    }
}