using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SFXSlider;
    [SerializeField] AudioClip testSFXClip;

    private void Start()
    {
        SetMusicVolume();
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("Music", getLogarithmicVolume(volume));
    }
    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        audioMixer.SetFloat("SFX", getLogarithmicVolume(volume));
        AudioManager.Instance.PlaySFX(testSFXClip);
    }

    private float getLogarithmicVolume(float linearVolume)
    {
        if (linearVolume == 0)
        {
            return -80f;
        } else
        {
            return 40 * Mathf.Log10(linearVolume);
        }
    }
}
