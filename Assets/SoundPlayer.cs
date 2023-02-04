using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource gore, tooth,hammer;

    public void PlayAudio(AudioSource source)
    {
        source.Play();
    }
    public void PlayAudioDelayed(AudioSource source, float delay)
    {
        source.PlayDelayed(delay);
    }

}
