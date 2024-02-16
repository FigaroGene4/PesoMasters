using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Slider MusicSlider, SoundSlider, SpeechSlider;

    public void ToggleMusic()
    {
        SoundManager.Instance.ToggleMusic();
    }

    public void ToggleSound()
    {
        SoundManager.Instance.ToggleSound();
    }

    public void ToggleSpeech()
    {
        SoundManager.Instance.ToggleSpeech();
    }

    public void AdjustMusicVolume()
    {
        SoundManager.Instance.SetMusicVolume(MusicSlider.value);
    }

    public void AdjustSoundVolume()
    {
        SoundManager.Instance.SetSFXVolume(SoundSlider.value);
    }

    public void AdjustSpeechVolume()
    {
        SoundManager.Instance.SetSpeechVolume(SpeechSlider.value);
    }
}
