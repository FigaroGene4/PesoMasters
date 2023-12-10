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
            Debug.Log("Sound not Found");
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
            Debug.Log("Sound not Found");
        }
        else
        {
            // Stop any currently playing sound on the sfxSource
            sfxSource.Stop();

            // Play the new sound effect
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void PlaySpeech(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Speech not Found");
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
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SoundVolume(float volume)
    {
        sfxSource.volume = volume;
    }
    public void SpeechVolume(float volume)
    {
        speechSource.volume = volume;
    }
}
