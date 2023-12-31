using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource; 

    public AudioClip background;
    public AudioClip spawning;
    public AudioClip enterGoal; 

    //voice clips
    //public AudioClip death;
    //public AudioClip goblin_death;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
