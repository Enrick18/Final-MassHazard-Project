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
    public AudioClip attacking;
    public AudioClip death;

    private void Start()
    {
        musicSource.clip = background;
    }
}
