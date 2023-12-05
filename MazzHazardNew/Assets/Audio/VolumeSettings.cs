using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        SetMusicVolume();
        SetSFXVolume();
    }
    public void SetMusicVolume()
    {
        float music_volume = musicSlider.value;
        myMixer.SetFloat("MusicVolume", Mathf.Log10(music_volume) * 20);
    }

    public void SetSFXVolume()
    {
        float sfx_volume = sfxSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(sfx_volume) * 20);
    }
}
