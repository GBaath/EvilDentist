using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioSource gore, tooth,hammer;
    public AudioSource[] hurtsounds;

    public void PlayAudio(AudioSource source)
    {
        source.Play();
    }
    public void PlayAudioDelayed(AudioSource source, float delay)
    {
        source.PlayDelayed(delay);
    }
    public void PlayRandomAudio(AudioSource[] sources)
    {
        sources[Random.Range(0, sources.Length)].Play();
    }

}
