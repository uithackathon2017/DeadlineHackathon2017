using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum AudioType
{
    BACKGROUND = 1,
    BOW_FIRE = 2,
    LEVEL_UP =3,
    ENEMY_HIT = 4,
    ENEMY_DIE = 5,
	UI_CLICK =10,
	PERFECT =11,
    BOUNCE = 12
}

[System.Serializable]
public class AudioProfile
{
    public AudioType type;
    public AudioClip audio;
}
public class AudioManger1 : MonoSingleton<AudioManger1> {

    public List<AudioProfile> listAudio;
    public Dictionary<AudioType, AudioClip> dicAudio;
    public AudioSource audioSource;
    public AudioSource audioSourceBG;
	// Use this for initialization
	void Start () {
        InitDictionary();
	}
	public void InitDictionary()
    {
        dicAudio = new Dictionary<AudioType, AudioClip>();
        foreach(AudioProfile var in listAudio)
        {
            dicAudio.Add(var.type, var.audio);
        }
    }
	
    public AudioClip GetAudio(AudioType type)
    {
        if(dicAudio.ContainsKey(type))
        {
            return dicAudio[type];
        }
#if UNITY_EDITOR
        Debug.Log("ko co type audio nay!");
#endif
        return null;
    }
    public void PlayAudioByType(AudioType _type,bool _loop)
    {
        AudioClip audio = GetAudio(_type);
        if(audio)
        {
            audioSource.loop = _loop;
            audioSource.clip = audio;
            audioSource.Play();
        }
    }
    public void PlayOneShot(AudioType _type)
    {
        AudioClip audio = GetAudio(_type);
        if (audio)
        {
            audioSource.PlayOneShot(audio);
        }
    }

    public void StopAudiobyType(AudioType _type)
    {
        AudioClip audio = GetAudio(_type);
        if (audio)
        {
            audioSource.clip = audio;
            audioSource.Stop();
        }
    }
    
    public void SetMuteAudio()
    {
        if(audioSource)
        {
            audioSource.mute = true;
        }
    }

    public void SetAudio()
    {
        if(audioSource)
        {
            audioSource.mute = false;
        }
    }

    public void SetNoMusic()
    {
        audioSourceBG.mute = true;
    }

    public void SetMusic()
    {
        audioSourceBG.mute = false;
    }
}
