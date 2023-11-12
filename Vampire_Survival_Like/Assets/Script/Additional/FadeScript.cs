using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    void Awake()
    {
        FadeIn();
    }
    
    
    // 페이드 인 아웃
    public void FadeInFadeOut()
    {
        StartCoroutine(FadeInFadeOutFlow());
    }
    
    IEnumerator FadeInFadeOutFlow()
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
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    
    //페이드 인은 검은색에서 본 영상으로
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
    //페이드 아웃은 본 영상에서 검은색으로

    public void FadeOut()
    {
        StartCoroutine(FadeOutFlow());
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
        
        Panel.gameObject.SetActive(false);
        yield return null;
    }
}