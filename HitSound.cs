using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class HitSound : MonoBehaviour, IHitable {

    public AudioClip clip;

    public void Hit()
    {
        audio.PlayOneShot(clip);
    }
}
