using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffectForLevelEditor : MonoBehaviour
{
    public AudioSource soundPlayer;

    public void playThisSoundEffect()
    {
        soundPlayer.Play();
    }
}
