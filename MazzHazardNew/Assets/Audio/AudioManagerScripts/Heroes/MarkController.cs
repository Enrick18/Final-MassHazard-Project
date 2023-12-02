using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class MarkController : MonoBehaviour
{
    [SerializeField] AudioSource MarkSFXSource;

    public AudioClip attacking;
    public AudioClip death;

    private void Awake()
    {
        MarkSFXSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();        
    }

    private void DamageHit(AudioClip clip)
    {
        MarkSFXSource.PlayOneShot(clip);
    }
}
