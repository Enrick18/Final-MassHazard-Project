using UnityEngine;

public class CharacterAudio : MonoBehaviour
{
    public AudioClip attackSound;
    public AudioClip deathSound;

    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component on the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAttackSound()
    {
        // Play the attack sound
        audioSource.clip = attackSound;
        audioSource.Play();
    }

    public void PlayDeathSound()
    {
        // Play the death sound
        audioSource.clip = deathSound;
        audioSource.Play();
    }
}