using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("#BGM")]
    public AudioClip bgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;
    AudioHighPassFilter bgmEffect;

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channelIndex; 

    public enum Sfx { Select, Hit, Dead, Bomb, ExeGet, Boom, Gun, Gameover1 }

    void Awake()
    {
        instance = this;
        Init();
    }
     
    void Init()
    {
        // 배경음 플레이어 초기화
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;
        //강화창 브금조절
        bgmEffect = Camera.main.GetComponent<AudioHighPassFilter>();


        // 효과음 플레이어 초기화
        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for(int index=0; index < sfxPlayers.Length; index++) {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].bypassListenerEffects = true;
            sfxPlayers[index].volume = sfxVolume;
        }
    }

    public void PlayBgm(bool isPlay)
    {
        Debug.Log("PlayBgm called with isPlay: " + isPlay);
        
        if (isPlay){
            bgmPlayer.Play();
        }
        else {
            bgmPlayer.Stop();
        }
    }

     public void EffectBgm(bool isPlay)
    {
        bgmEffect.enabled = isPlay;
    }
    
    public void PlaySfx(Sfx sfx)
    {
        for (int index=0; index < sfxPlayers.Length; index++){
            int  loopIndex = (index + channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying)
            continue;

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx];
            sfxPlayers[loopIndex].Play();
            break;
        }
        
    }

    // void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    // {
    //     // 씬이 로드될 때 호출되는 콜백
    //     SceneAudio sceneAudio = sceneAudios.Find(x => x.sceneName == scene.name);

    //     if (sceneAudio != null && sceneAudio.bgmClip != null)
    //     {
    //         // 해당 씬의 배경음을 설정하고 딜레이를 추가하여 재생
    //         bgmPlayer.clip = sceneAudio.bgmClip;
    //         PlayBgmWithDelay(sceneAudio.bgmDelay);
    //     }
    //     else
    //     {
    //         // 씬에 대한 설정이 없으면 배경음 정지
    //         PlayBgm(false);
    //     }
    // }
}
