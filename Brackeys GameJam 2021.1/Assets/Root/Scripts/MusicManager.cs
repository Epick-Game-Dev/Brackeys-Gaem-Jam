using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public static void StartMusic()
    {
        source.Play();
    }

    public static void StopMusic()
    {
        source.Stop();
    }

    public static void PauseMusic()
    {
        source.Pause();
    }

    public static void UnpauseMusic()
    {
        source.UnPause();
    }

    public static void ChangeVolume(float newVolume)
    {
        source.volume = newVolume;
    }
}
