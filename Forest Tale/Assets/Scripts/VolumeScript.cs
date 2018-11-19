using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour {

    Slider VolumeSlider;
   public AudioMixer audioMixer;

    private void Awake()
    {
        VolumeSlider = GetComponent<Slider>();
    }

    public void AudioVolume()
    {
        audioMixer.SetFloat("masterVolume", VolumeSlider.value);
    }
}
