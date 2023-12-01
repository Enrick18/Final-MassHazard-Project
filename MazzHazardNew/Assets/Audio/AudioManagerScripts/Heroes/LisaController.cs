using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UIElements;

public class LisaController : MonoBehaviour
{
    [SerializeField] AudioSource SFXSource;

    public AudioClip attacking;
    public AudioClip death;

    public void LisaPlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
