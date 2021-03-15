using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    public static int clip = 0;
    public static float musicVolume = 1f;
    public static float musicTime = 0f;
    public AudioSource music;
    public AudioClip[] clips;

    void Start()
    {
        music.clip = clips[clip];
        music.volume = musicVolume;
        music.time = musicTime;
        music.Play();
    }

    void Update()
    {
        musicTime = music.time;
    }
}
