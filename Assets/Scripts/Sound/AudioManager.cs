using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    public AudioClip titlescreen;
    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;
    public AudioClip click;

    private void Awake()
    {
        Debug.Log(this);
        Instance = this;
    }

    public void Pause()
    {
        musicSource.Pause();
        SFXSource.Stop();
    }

    public void TitleScreen()
    {
        musicSource.clip = titlescreen;
        musicSource.Play();
    }
    public void Level(int levelIndex)
    {
        if (levelIndex == 1)
            musicSource.clip = music1;
        else if (levelIndex == 2)
            musicSource.clip = music2;
        else if (levelIndex == 3)
            musicSource.clip = music3;
        else if (levelIndex == 4)
            musicSource.Stop();
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
