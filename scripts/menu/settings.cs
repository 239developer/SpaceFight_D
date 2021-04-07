using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    public Slider music, musicClip;
    private static int startClip;

    void Start()
    {
        startClip = audioController.clip;
        music.value = audioController.musicVolume;
        musicClip.value = audioController.clip;
    }

    void Update()
    {
        audioController.musicVolume = music.value;
        audioController.clip = (int)musicClip.value;
        if(startClip != audioController.clip)
        {
            audioController.musicTime = 0f;
        }
    }
}
