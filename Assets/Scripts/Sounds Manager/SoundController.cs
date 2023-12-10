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
    public void MusicVolume()
    {
        SoundManager.Instance.MusicVolume(MusicSlider.value);
    }
    public void SoundVolume()
    {
        SoundManager.Instance.SoundVolume(SoundSlider.value);
    }
    public void SpeechVolume()
    {
        SoundManager.Instance.SpeechVolume(SpeechSlider.value);
    }
    

}
