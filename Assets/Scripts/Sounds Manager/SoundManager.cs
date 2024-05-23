using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    public AudioClip themeDefault;
    public AudioClip themeGamePlay;
    public AudioClip loading;
    public AudioClip click;
    public AudioClip win;
    //public AudioClip gameover;
     

    private float defaultVolume = 0.25f;

    private void Awake()
    {
        if (soundManager == null)
        {
            soundManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.clip = themeDefault;
        musicSource.Play();
        SetMusicVolume(defaultVolume);
        SetSFXVolume(defaultVolume);
    }

    public void PlayMusic(AudioClip clip)
    {
       musicSource.clip = clip;
       musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
       sfxSource.PlayOneShot(clip);
    }
    public void StopMusic() {
        soundManager.musicSource.Stop();
    }
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSound()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
