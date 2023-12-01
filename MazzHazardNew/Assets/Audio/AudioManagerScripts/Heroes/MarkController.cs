using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class MarkController : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;

    public AudioClip attacking;
    public AudioClip death;

    public void MarkPlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
