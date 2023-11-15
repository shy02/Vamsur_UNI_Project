using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager A_instance;

    [Header("#BGM")]
    public AudioClip bgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;


    [Header("#SFX")] 
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channelIndex;

    public enum Sfx
    {
        select, c_dead, c_hit, exp, drink, firework, book, bomb, gun, e_hit, e_dead, pattern1, pattern2, pattern3, pattern4, pattern5, pattern6, pattern7,
    } // 효과음 열거

    void Awake()
    {
        A_instance = this;
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

        // 효과음 플레이어 초기화
        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].volume = sfxVolume;
        }
    }

    public void PlayBgm(bool isPlay)
    {
       // Debug.Log(isPlay);

        if (isPlay)
        {
            bgmPlayer.Play();
            Debug.Log(isPlay);

        }
        else
        {
            bgmPlayer.Stop();
            Debug.Log(isPlay);

        }

    }

    public void EffectBgm(bool isPlay)
    {

    }
    public void PlaySfx(Sfx sfx)
    {
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopIndex = (index + channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying)
                continue;

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx];
            sfxPlayers[loopIndex].Play();
            break;
        }
    }

    public void ChangeBgmSound(float value)
    {
        bgmPlayer.volume = value;
    }

    public void ChangeSfxSound(float value)
    {
        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            int loopIndex = (index + channelIndex) % sfxPlayers.Length;

            sfxPlayers[index].volume = value;
        }
    }
}
