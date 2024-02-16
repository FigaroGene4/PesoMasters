using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public Sound[] musicSounds, sfxSounds, speechSounds;
    public AudioSource musicSource, sfxSource, speechSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Theme");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Music not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("SFX not found");
        }
        else
        {
            sfxSource.Stop();
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void PlaySpeech(string name)
    {
        Sound s = Array.Find(speechSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Speech not found");
        }
        else
        {
            speechSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSound()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void ToggleSpeech()
    {
        speechSource.mute = !speechSource.mute;
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = 0.25f;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = 0.25f;
    }

    public void SetSpeechVolume(float volume)
    {
        speechSource.volume = 0.50f;
    }
}
