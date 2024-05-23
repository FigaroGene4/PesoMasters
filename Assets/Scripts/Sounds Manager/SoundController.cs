using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public Slider MusicSlider, SoundSlider;
    public Button MusicButton, SoundButton;

    private bool musicMuted = false;
    private bool soundMuted = false;

    private void Start()
    {
    }

    public void ToggleMusic()
    {
        SoundManager.soundManager.ToggleMusic();
        musicMuted = !musicMuted;
        if (musicMuted)
            MusicSlider.value = 0f; // Set slider value to 0 when music is muted
    }

    public void ToggleSound()
    {
        SoundManager.soundManager.ToggleSound();
        soundMuted = !soundMuted;
        if (soundMuted)
            SoundSlider.value = 0f; // Set slider value to 0 when sound is muted
    }

    public void AdjustMusicVolume()
    {
        SoundManager.soundManager.SetMusicVolume(MusicSlider.value);
    }

    public void AdjustSoundVolume()
    {
        SoundManager.soundManager.SetSFXVolume(SoundSlider.value);
    }
}
