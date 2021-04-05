using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    public Slider music;

    void Start()
    {
        music.value = audioController.musicVolume;
    }

    void Update()
    {
        audioController.musicVolume = music.value;
    }

    void ChangeMusic()
    {

    }
}
